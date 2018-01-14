using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;
using database.models;
using database.Helpers;
using System.Windows.Controls;

namespace database
{
    /// <summary>
    /// Interaction logic for ShowData.xaml
    /// </summary>
    public partial class ShowData : Window
    {
        public int mode;
        private IList<dynamic> DataFromDatabase;

        public ShowData(IEnumerable<dynamic> Data, int UpdatePermission)
        {
            InitializeComponent();
            mode = UpdatePermission;
            DataFromDatabase = Data.ToList();
            if (UpdatePermission > 0)
            {
                AdvancedDataGrid.Visibility = Visibility.Visible;
                this.AdvancedDataGrid.ItemsSource = DataFromDatabase;
            }
            else
            {
                DataGrid.Visibility = Visibility.Visible;
                this.DataGrid.ItemsSource = DataFromDatabase;
            }
        }

        private void ChangeText(object sender, RoutedEventArgs e)
        {
            var selectedIndex = DataGridRow.GetRowContainingElement
              (sender as FrameworkElement).GetIndex();

            if (mode == 1)
            {
                Bron obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else if (mode == 2)
            {
                Amunicja obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else if (mode == 3)
            {
                Hurtowe obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else if (mode == 4)
            {
                Detaliczne obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else if (mode == 5)
            {
                Dostawa obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else if (mode == 6)
            {
                Kategoria obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else if (mode == 7)
            {
                Material obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else if (mode == 8)
            {
                Pracownik obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else if (mode == 9)
            {
                Produkcja obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
            else
            {
                Zamowienie obiekt = DataFromDatabase.ElementAt(selectedIndex);
                ModifyForm mForm = new ModifyForm(obiekt, mode);
                mForm.Show();
            }
        }
    }
}
