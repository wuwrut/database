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
        private int formMode;
        public AccountantForm(int command)
        {
            InitializeComponent();

            formMode = command;

            switch (formMode)
            {              
                case (0):
                    Label1.Content = "PESEL";
                    Label2.Content = "Name";
                    Label3.Content = "Surname";
                    Label4.Content = "Certificate";
                    Label5.Content = "Revenue";
                    break;
                case (1):
                    Label1.Content = "Name";
                    Label2.Content = "Amount";
                    Label3.Content = "Price";
                    Label4.Visibility = Visibility.Hidden;
                    Label5.Visibility = Visibility.Hidden;
                    Box4.Visibility = Visibility.Hidden;
                    Box5.Visibility = Visibility.Hidden;
                    break;
                default:
                    Label1.Content = "Name";
                    Label2.Content = "Category";
                    Label3.Content = "Price";
                    Label4.Visibility = Visibility.Hidden;
                    Label5.Visibility = Visibility.Hidden;
                    Box4.Visibility = Visibility.Hidden;
                    Box5.Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            switch (formMode)
            {
                case (0):
                    break;
                case (1):
                    break;
                default:
                    break;
            }
        }
    }
}
