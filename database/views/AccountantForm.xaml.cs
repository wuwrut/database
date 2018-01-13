using database.models;
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
        private Brush _defaultBrush; 

        public AccountantForm(int command)
        {
            InitializeComponent();

            _defaultBrush = Box1.BorderBrush;
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
            DatabaseModel DataModel = new DatabaseModel();

            switch (formMode)
            {
                case (0):
                    if (long.TryParse(Box1.Text, out long r1) && Box2.Text.Length > 0 && Box3.Text.Length > 0 && Box4.Text.Length > 0 && int.TryParse(Box5.Text, out int r2))
                    {
                        try
                        {
                            DataModel.CreateWorker(long.Parse(Box1.Text), Box2.Text, Box3.Text, Box4.Text, int.Parse(Box5.Text));
                            this.Close();
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        if (!long.TryParse(Box1.Text, out long r6))
                            Box1.BorderBrush = Brushes.Red;
                        else
                            Box2.BorderBrush = _defaultBrush;

                        if (Box2.Text.Length == 0)
                            Box2.BorderBrush = Brushes.Red;
                        else
                            Box2.BorderBrush = _defaultBrush;

                        if (Box3.Text.Length == 0)
                            Box3.BorderBrush = Brushes.Red;
                        else
                            Box3.BorderBrush = _defaultBrush;

                        if (Box4.Text.Length == 0)
                            Box4.BorderBrush = Brushes.Red;
                        else
                            Box4.BorderBrush = _defaultBrush;

                        if (int.TryParse(Box5.Text, out int r7))
                            Box5.BorderBrush = Brushes.Red;
                        else
                            Box5.BorderBrush = _defaultBrush;
                    }
                    break;
                case (1):
                    if (Box1.Text.Length > 0 && int.TryParse(Box2.Text, out int r3) && Decimal.TryParse(Box3.Text, out Decimal r4))
                    {
                        try
                        {
                            DataModel.CreateAmmo(Box1.Text, int.Parse(Box2.Text), Decimal.Parse(Box3.Text));
                            this.Close();
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        if (Box1.Text.Length == 0)
                            Box1.BorderBrush = Brushes.Red;
                        else
                            Box2.BorderBrush = _defaultBrush;

                        if (!int.TryParse(Box2.Text, out int r8))
                            Box2.BorderBrush = Brushes.Red;
                        else
                            Box2.BorderBrush = _defaultBrush;

                        if (!Decimal.TryParse(Box3.Text, out Decimal r9))
                            Box3.BorderBrush = Brushes.Red;
                        else
                            Box3.BorderBrush = _defaultBrush;
                    }
                    break;
                default:
                    if (Box1.Text.Length > 0 && Box2.Text.Length > 0 && Decimal.TryParse(Box3.Text, out Decimal r5))
                    {
                        try
                        {
                            DataModel.CreateWeapon(Box1.Text, Box2.Text, Decimal.Parse(Box3.Text));
                            this.Close();
                        }catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        if (Box1.Text.Length == 0)
                            Box1.BorderBrush = Brushes.Red;
                        else
                            Box2.BorderBrush = _defaultBrush;

                        if (Box2.Text.Length == 0)
                            Box2.BorderBrush = Brushes.Red;
                        else
                            Box2.BorderBrush = _defaultBrush;

                        if (!Decimal.TryParse(Box3.Text, out Decimal r11))
                            Box3.BorderBrush = Brushes.Red;
                        else
                            Box3.BorderBrush = _defaultBrush;
                    }
                    break;
            }
        }
    }
}
