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

namespace database
{
    /// <summary>
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {

        public ICollection<Tuple<String, int>> ammo;
        public ICollection<Tuple<String, int>> weapons;

        public AddOrder()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(ComboType.SelectedItem.ToString() == "Bron")
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
        }

        private void AddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            DatabaseModel DataModel = new DatabaseModel();


            if (RadioButton.IsChecked == true && BoxComments.Text.Length > 1)
            {
                //DataModel.CreateOrder(DatePicker.SelectedDate.Value, ammo, weapons, WPNumber.Text, true, BoxComments.Text);
            }
            else if (RadioButton.IsChecked == true)
            {
                //DataModel.CreateOrder(DatePicker.SelectedDate.Value, ammo, weapons, WPNumber.Text, true);
            }
            else if (BoxComments.Text.Length > 1)
            {
                //DataModel.CreateOrder(DatePicker.SelectedDate.Value, ammo, weapons, "", false, BoxComments.Text);
            }
            else
            {
                //DataModel.CreateOrder(DatePicker.SelectedDate.Value, ammo, weapons, "", false);
            }
        }

        
    }
}
