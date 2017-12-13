using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace database
{
    /// <summary>
    /// Interaction logic for ShowData.xaml
    /// </summary>
    public partial class ShowData : Window
    {
        public string TextFromLastView;

        public ShowData(object Data, bool UpdatePermission)
        { 
            InitializeComponent();
            
        }
    }
}
