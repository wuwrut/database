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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Window_Loaded();
        }

        private void Window_Loaded()
        {
            loginbox.Items.Add("User");
            loginbox.Items.Add("Admin");
            loginbox.Items.Add("Accountant");

            loginbox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (loginbox.SelectedIndex) {
                case 1:
                    Admin newAdminWindow = new Admin();
                    newAdminWindow.Show();
                    break;
                case 2:
                    Accountant newAccountantWindow = new Accountant();
                    newAccountantWindow.Show();
                    break;
                default:
                    User newUserWindow = new User();
                    newUserWindow.Show();
                    break;
            }   
            this.Close();
        }

        
    }
}
