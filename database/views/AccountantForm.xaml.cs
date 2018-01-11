using System;
using System.Collections.Generic;
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

namespace database
{
    /// <summary>
    /// Interaction logic for AccountantForm.xaml
    /// </summary>
    public partial class AccountantForm : Window
    {
        public AccountantForm(int command)
        {            
            switch (command)
            {
                case (0):

                    break;
                case (1):

                    break;
                default:

                    break;
            }
            InitializeComponent();
        }
    }
}
