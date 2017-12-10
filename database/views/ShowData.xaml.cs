using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace database
{
    /// <summary>
    /// Interaction logic for ShowData.xaml
    /// </summary>
    public partial class ShowData : Window
    {
        public string TextFromLastView;

        public ShowData(string Text)
        { 
            InitializeComponent();
            this.TextFromLastView = Text;
            DataBox.Text = TextFromLastView;
        }
    }
}
