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

        public ICollection<Tuple<String, int>> ammo;
        public ICollection<Tuple<String, int>> weapons;
        private Brush _defaultBrush;

        public AddOrder()
        {
            InitializeComponent();

            _defaultBrush = DatePicker.BorderBrush;

            List<String> cType = new List<String> { "Bron", "Amunicja" };
            ComboType.ItemsSource = cType;
            ComboType.SelectedItem = cType[0];
            DatePicker.SelectedDate = DateTime.Today.AddDays(4);

            //TODO Subtype implementation with query!!!
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
                    //DataModel.CreateOrder(DatePicker.SelectedDate, ammo, weapons, WPNumber.Text, true, BoxComments.Text);
                }
                else if (RadioButton.IsChecked == true)
                {
                    //DataModel.CreateOrder(DatePicker.SelectedDate, ammo, weapons, WPNumber.Text, true);
                }
                else if (BoxComments.Text.Length > 1)
                {
                    //DataModel.CreateOrder(DatePicker.SelectedDate, ammo, weapons, "", false, BoxComments.Text);
                }
                else
                {
                    //DataModel.CreateOrder(DatePicker.SelectedDate, ammo, weapons, "", false);
                }
            }
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
    }
}
