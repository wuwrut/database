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
        public string TextFromLastView;
        private IList<dynamic> DataFromDatabase;

        public ShowData(IEnumerable<dynamic> Data, bool UpdatePermission)
        {
            InitializeComponent();
            DataFromDatabase = Data.ToList();
            if (UpdatePermission)
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

            Bron bron = DataFromDatabase.ElementAt(selectedIndex);
            //TODO Form with all the tables

            
        }
    }
}
