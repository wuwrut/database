using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using database.models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace database
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {

        public ICollection<Tuple<String, int>> ammo = new List<Tuple<String, int>>();
        public ICollection<Tuple<String, int>> weapons = new List<Tuple<String, int>>();
        private Brush _defaultBrush;
        private List<String> subBron = new List<String>();
        private List<String> subAmunicja = new List<String>();

        public AddOrder()
        {
            InitializeComponent();

            _defaultBrush = DatePicker.BorderBrush;

            List<String> cType = new List<String> { "Bron", "Amunicja" };
            ComboType.ItemsSource = cType;
            ComboType.SelectedItem = cType[0];
            ComboSubtype.ItemsSource = subBron;
            DatePicker.SelectedDate = DateTime.Today.AddDays(4);

            DatabaseModel DataModel = new DatabaseModel();

            IEnumerable<Bron> enumBron = DataModel.Query<Bron>("SELECT NAZWA FROM BRON");
            foreach(Bron eBron in enumBron){
                subBron.Add(eBron.Nazwa);
            }
            
            IEnumerable<Amunicja> enumAmunicja = DataModel.Query<Amunicja>("SELECT KALIBER FROM AMUNICJA");
            foreach (Amunicja eAmunicja in enumAmunicja)
            {
                subAmunicja.Add(eAmunicja.Kaliber);
            }

            ComboSubtype.SelectedItem = subBron[0];
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            if (ComboType.SelectedItem.ToString() == "Bron")
            {
                String weaponName = ComboSubtype.SelectedItem.ToString();
                int quantity = int.Parse(BoxQuantity.Text.ToString());
                weapons.Add(Tuple.Create(weaponName, quantity));
            }
            else
            {
                String ammoName = ComboSubtype.SelectedItem.ToString();
                int quantity = int.Parse(BoxQuantity.Text.ToString());
                ammo.Add(Tuple.Create(ammoName, quantity));
            }

            if (BoxAdded.Text == "Your current order is empty!")
            {
                BoxAdded.Text = "";
            }

            BoxAdded.AppendText(ComboSubtype.SelectedItem.ToString() + " x" + BoxQuantity.Text);
            BoxAdded.AppendText(Environment.NewLine);
        }

        private void AddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.SelectedDate < DateTime.Today.AddDays(4))
            {
                AddNewOrder.BorderBrush = Brushes.Red;
            }
            else
            {
                DatabaseModel DataModel = new DatabaseModel();

                if (RadioButton.IsChecked == true && BoxComments.Text.Length > 1)
                {
                    DataModel.CreateOrder(DatePicker.SelectedDate.Value, ammo, weapons, WPNumber.Text.ToString(), true, BoxComments.Text);
                }
                else if (RadioButton.IsChecked == true)
                {
                    DataModel.CreateOrder(DatePicker.SelectedDate.Value, ammo, weapons, WPNumber.Text.ToString(), true);
                }
                else if (BoxComments.Text.Length > 1)
                {
                    DataModel.CreateOrder(DatePicker.SelectedDate.Value, ammo, weapons, WPNumber.Text.ToString(), false, BoxComments.Text);
                }
                else
                {
                    DataModel.CreateOrder(DatePicker.SelectedDate.Value, ammo, weapons, WPNumber.Text.ToString(), false);
                }
            }
            this.Close();
        }

        private void BoxQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DatePicker_DateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.SelectedDate < DateTime.Today.AddDays(4))
            {
                DatePicker.BorderBrush = Brushes.Red;
            }
            else
            {
                DatePicker.BorderBrush = _defaultBrush;
            }
        }

        private void NumericOnly(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }


        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboType.SelectedItem.ToString() == "Bron")
            {
                ComboSubtype.ItemsSource = subBron;
            }
            else
            {
                ComboSubtype.ItemsSource = subAmunicja;
            }
        }
    }
}
