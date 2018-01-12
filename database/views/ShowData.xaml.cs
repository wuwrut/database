using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;
using database.models;
using database.Helpers;

namespace database
{
    /// <summary>
    /// Interaction logic for ShowData.xaml
    /// </summary>
    public partial class ShowData : Window
    {
        public string TextFromLastView;

        public ShowData(IEnumerable<dynamic> Data, bool UpdatePermission)
        {
            InitializeComponent();
            if (UpdatePermission)
            {
                AdvancedDataGrid.Visibility = Visibility.Visible;
                this.AdvancedDataGrid.ItemsSource = Data;
            }
            else
            {
                DataGrid.Visibility = Visibility.Visible;
                this.DataGrid.ItemsSource = Data;
            }
        }

        private void ChangeText(object sender, RoutedEventArgs e)
        {

        }
    }
}
