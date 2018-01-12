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
            this.DataGrid.ItemsSource = Data;
        }
    }
}
