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
    /// Interaction logic for ModifyForm.xaml
    /// </summary>
    public partial class ModifyForm : Window
    {
        private int class_mode;
        private object sthToChange;
        private ShowData lastData;
        private Brush _defaultBrush;

        public ModifyForm(object toChange, int mode, ShowData lastWindow)
        {

            InitializeComponent();
            class_mode = mode;
            sthToChange = toChange;
            lastData = lastWindow;
            _defaultBrush = Button1.BorderBrush;

            if (mode == 1)
            {
                Bron typeObject = (Bron)toChange;
                Label1.Content = "Numer_Seryjny";
                Label2.Content = "Nazwa";
                Label3.Content = "Cena";
                Label4.Content = "PRODUKCJA_Numer_Produkcyjny";
                Label5.Content = "KATEGORIA_ID";
                Box1.Text = typeObject.Numer_Seryjny.ToString();
                Box2.Text = typeObject.Nazwa.ToString();
                Box3.Text = typeObject.Cena.ToString();
                Box4.Text = typeObject.PRODUKCJA_Numer_Produkcyjny.ToString();
                Box5.Text = typeObject.KATEGORIA_ID.ToString();
            }
            else if (mode == 2)
            {
                Amunicja typeObject = (Amunicja)toChange;
                Label1.Content = "Numer_Pudelka";
                Label2.Content = "Kaliber";
                Label3.Content = "Ilosc_Amunicji";
                Label4.Content = "Cena";
                Label5.Content = "PRODUKCJA_Numer_Produkcji";
                Box1.Text = typeObject.Numer_Pudelka.ToString();
                Box2.Text = typeObject.Kaliber.ToString();
                Box3.Text = typeObject.Ilosc_Amunicji.ToString();
                Box4.Text = typeObject.Cena.ToString();
                Box5.Text = typeObject.PRODUKCJA_Numer_Produkcji.ToString();
            }
            else if (mode == 3)
            {
                Hurtowe typeObject = (Hurtowe)toChange;
                Label1.Content = "Numer_Zamowienia";
                Label2.Content = "Zezwolenie_Na_Handel";
                Label3.Visibility = Visibility.Hidden;
                Label4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden;
                Box1.Text = typeObject.Numer_Zamowienia.ToString();
                Box2.Text = typeObject.Zezwolenie_Na_Handel.ToString();
                Box3.Visibility = Visibility.Hidden;
                Box4.Visibility = Visibility.Hidden;
                Box5.Visibility = Visibility.Hidden;
            }
            else if (mode == 4)
            {
                Detaliczne typeObject = (Detaliczne)toChange;
                Label1.Content = "Numer_Zamowienia";
                Label2.Content = "Zezwolenie_Na_Bron";
                Label3.Visibility = Visibility.Hidden;
                Label4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden;
                Box1.Text = typeObject.Numer_Zamowienia.ToString();
                Box2.Text = typeObject.Zezwolenie_Na_Bron.ToString();
                Box3.Visibility = Visibility.Hidden;
                Box4.Visibility = Visibility.Hidden;
                Box5.Visibility = Visibility.Hidden;
            }
            else if (mode == 5)
            {
                Dostawa typeObject = (Dostawa)toChange;
                Label1.Content = "Nr_Dostawy";
                Label2.Content = "Nazwa_dostawcy";
                Label3.Content = "Ilosc_Amunicji";
                Label4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden;
                Box1.Text = typeObject.Nr_Dostawy.ToString();
                Box2.Text = typeObject.Nazwa_dostawcy.ToString();
                Box3.Text = typeObject.Koszt_Calkowity.ToString();
                Box4.Visibility = Visibility.Hidden;
                Box5.Visibility = Visibility.Hidden;
            }
            else if (mode == 6)
            {
                Kategoria typeObject = (Kategoria)toChange;
                Label1.Content = "ID";
                Label2.Content = "Nazwa";
                Label3.Visibility = Visibility.Hidden;
                Label4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden;
                Box1.Text = typeObject.ID.ToString();
                Box2.Text = typeObject.Nazwa.ToString();
                Box3.Visibility = Visibility.Hidden;
                Box4.Visibility = Visibility.Hidden;
                Box5.Visibility = Visibility.Hidden;
            }
            else if (mode == 7)
            {
                Material typeObject = (Material)toChange;
                Label1.Content = "ID";
                Label2.Content = "Nazwa";
                Label3.Content = "Ilosc";
                Label4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden;
                Box1.Text = typeObject.ID.ToString();
                Box2.Text = typeObject.Nazwa.ToString();
                Box3.Text = typeObject.Ilosc.ToString();
                Box4.Visibility = Visibility.Hidden;
                Box5.Visibility = Visibility.Hidden;
            }
            else if (mode == 8)
            {
                Pracownik typeObject = (Pracownik)toChange;
                Label1.Content = "PESEL";
                Label2.Content = "Imie";
                Label3.Content = "Nazwisko";
                Label4.Content = "Zaswiadczenie_O_Niekaralnosci";
                Label5.Visibility = Visibility.Hidden;
                Box1.Text = typeObject.PESEL.ToString();
                Box2.Text = typeObject.Imie.ToString();
                Box3.Text = typeObject.Nazwisko.ToString();
                Box4.Text = typeObject.Zaswiadczenie_O_Niekaralnosci.ToString();
                Box5.Visibility = Visibility.Hidden;
            }
            else if (mode == 9)
            {
                Produkcja typeObject = (Produkcja)toChange;
                Label1.Content = "Numer_Produkcyjny";
                Label2.Content = "Nazwa_Produktu";
                Label3.Content = "Ilosc_Produktu";
                Label4.Visibility = Visibility.Hidden;
                Label5.Visibility = Visibility.Hidden;
                Box1.Text = typeObject.Numer_Produkcyjny.ToString();
                Box2.Text = typeObject.Nazwa_Produktu.ToString();
                Box3.Text = typeObject.Ilosc_Produktu.ToString();
                Box4.Visibility = Visibility.Hidden;
                Box5.Visibility = Visibility.Hidden;
            }
            else
            {
                Zamowienie typeObject = (Zamowienie)toChange;
                Label1.Content = "Numer_Zamowienia";
                Label2.Content = "Data_Dostawy";
                Label3.Content = "Data_Zamowienia";
                Label4.Content = "Uwagi";
                Label5.Visibility = Visibility.Hidden;
                Box1.Text = typeObject.Numer_Zamowienia.ToString();
                Box2.Text = typeObject.Data_Dostawy.ToString();
                Box3.Text = typeObject.Data_Zamowienia.ToString();
                Box4.Text = typeObject.Uwagi.ToString();
                Box5.Visibility = Visibility.Hidden;
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            object toChange = sthToChange;
            int mode = class_mode;

            DatabaseModel DataModel = new DatabaseModel();
            try
            {
                if (mode == 1)
                {
                    if (Box2.Text.Length > 0 && Decimal.TryParse(Box3.Text, out decimal r1) && Int64.TryParse(Box4.Text, out Int64 r2) && int.TryParse(Box5.Text, out int r6))
                    {
                        Bron typeObject = (Bron)toChange;
                        DataModel.Execute("UPDATE Bron SET Nazwa = '" + Box2.Text + "', Cena = '" + Box3.Text.Replace(",", ".") + "', PRODUKCJA_Numer_Produkcyjny = '" + Box4.Text + "', KATEGORIA_ID = '" + Box5.Text + "' WHERE Numer_Seryjny = '" + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }
                }
                else if (mode == 2)
                {
                    if (Box2.Text.Length > 0 && int.TryParse(Box3.Text, out int r3) && float.TryParse(Box4.Text, out float r4) && Int64.TryParse(Box5.Text, out Int64 r5))
                    {
                        Amunicja typeObject = (Amunicja)toChange;
                        DataModel.Execute("UPDATE Amunicja SET Kaliber = '" + Box2.Text + "', Ilosc_Amunicji = '" + Box3.Text + "', Cena = '" + Box4.Text.Replace(",", ".") + "', PRODUKCJA_Numer_Produkcji = '" + Box5.Text + "' WHERE Numer_Pudelka = " + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }
                }
                else if (mode == 3)
                {
                    if (Box2.Text.Length > 0)
                    {
                        Hurtowe typeObject = (Hurtowe)toChange;
                        DataModel.Execute("UPDATE Hurtowe SET Zezwolenie_Na_Handel = '" + Box2.Text + "' WHERE Numer_Zamowienia = '" + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }

                }
                else if (mode == 4)
                {
                    if (Box2.Text.Length > 0)
                    {
                        Detaliczne typeObject = (Detaliczne)toChange;
                        DataModel.Execute("UPDATE Detaliczne SET Zezwolenie_Na_Handel = '" + Box2.Text + "' WHERE Numer_Zamowienia = '" + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }                    
                }
                else if (mode == 5)
                {
                    if (Box2.Text.Length > 0 && Decimal.TryParse(Box3.Text, out Decimal r8))
                    {
                        Dostawa typeObject = (Dostawa)toChange;
                        DataModel.Execute("UPDATE Dostawa SET Nazwa_dostawcy = '" + Box2.Text + "', Koszt_Calkowity = '" + Box3.Text.Replace(",", ".") + "' WHERE Nr_Dostawy = '" + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }
                }
                else if (mode == 6)
                {
                    if (Box2.Text.Length > 0)
                    {
                        Kategoria typeObject = (Kategoria)toChange;
                        DataModel.Execute("UPDATE Kategoria SET Nazwa = '" + Box2.Text + "' WHERE ID = '" + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }
                }
                else if (mode == 7)
                {
                    if (Box2.Text.Length > 0 && int.TryParse(Box3.Text, out int r9))
                    {
                        Material typeObject = (Material)toChange;
                        DataModel.Execute("UPDATE Material SET Nazwa = '" + Box2.Text + "', Ilosc = '" + Box3.Text + "' WHERE ID = '" + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }
                }
                else if (mode == 8)
                {
                    if (Box2.Text.Length > 0 && Box3.Text.Length > 0 && Box4.Text.Length > 0)
                    {
                        Pracownik typeObject = (Pracownik)toChange;
                        DataModel.Execute("UPDATE Pracownik SET Imie = '" + Box2.Text + "', Nazwisko = '" + Box3.Text + "', Zaswiadczenie_O_Niekaralnosci = '" + Box4.Text + "' WHERE PESEL = '" + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }
                }
                else if (mode == 9)
                {
                    if (Box2.Text.Length > 0 && int.TryParse(Box3.Text, out int r10))
                    {
                        Produkcja typeObject = (Produkcja)toChange;
                        DataModel.Execute("UPDATE Produkcja SET Nazwa_Produktu = '" + Box2.Text + "', Ilosc_Produktu = '" + Box3.Text + "' WHERE Numer_Produkcyjny = '" + Box1.Text + "'");

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    if (DateTime.TryParse(Box2.Text, out DateTime r11) && DateTime.TryParse(Box3.Text, out DateTime r12) && int.TryParse(Box4.Text, out int r13))
                    {
                        Zamowienie typeObject = (Zamowienie)toChange;
                        DataModel.Execute("UPDATE Zamowienie SET Data_Dostawy = '" + Box2.Text + "', Data_Zamowienia = '" + Box3.Text + "', Uwagi = '" + Box4.Text + "' WHERE Numer_Zamowienia = '" + Box1.Text);

                        lastData.Close();
                        this.Close();
                    }
                    else
                    {
                        Button1.BorderBrush = Brushes.Red;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            object toChange = sthToChange;
            int mode = class_mode;

            DatabaseModel DataModel = new DatabaseModel();
            try
            {
                if (mode == 1)
                {
                    Bron typeObject = (Bron)toChange;
                    DataModel.Execute("DELETE FROM Bron WHERE Numer_Seryjny = " + typeObject.Numer_Seryjny.ToString());

                }
                else if (mode == 2)
                {
                    Amunicja typeObject = (Amunicja)toChange;
                    DataModel.Execute("DELETE FROM Amunicja WHERE Numer_Pudelka = " + typeObject.Numer_Pudelka.ToString());
                }
                else if (mode == 3)
                {
                    Hurtowe typeObject = (Hurtowe)toChange;
                    DataModel.Execute("DELETE FROM Hurtowe WHERE Numer_Zamowienia = " + typeObject.Numer_Zamowienia.ToString());
                }
                else if (mode == 4)
                {
                    Detaliczne typeObject = (Detaliczne)toChange;
                    DataModel.Execute("DELETE FROM Detaliczne WHERE Numer_Zamowienia = " + typeObject.Numer_Zamowienia.ToString());
                }
                else if (mode == 5)
                {
                    Dostawa typeObject = (Dostawa)toChange;
                    DataModel.Execute("DELETE FROM Dostawa WHERE Nr_Dostawy = " + typeObject.Nr_Dostawy.ToString());
                }
                else if (mode == 6)
                {
                    Kategoria typeObject = (Kategoria)toChange;
                    DataModel.Execute("DELETE FROM Kategoria WHERE ID = " + typeObject.ID.ToString());
                }
                else if (mode == 7)
                {
                    Material typeObject = (Material)toChange;
                    DataModel.Execute("DELETE FROM Material WHERE ID = " + typeObject.ID.ToString());
                }
                else if (mode == 8)
                {
                    Pracownik typeObject = (Pracownik)toChange;
                    DataModel.Execute("DELETE FROM Pracownik WHERE PESEL = " + typeObject.PESEL.ToString());

                }
                else if (mode == 9)
                {
                    Produkcja typeObject = (Produkcja)toChange;
                    DataModel.Execute("DELETE FROM Produkcja WHERE Numer_Produkcyjny = " + typeObject.Numer_Produkcyjny.ToString());
                }
                else
                {
                    Zamowienie typeObject = (Zamowienie)toChange;
                    DataModel.Execute("DELETE FROM Zamowienie WHERE Numer_Zamowienia = " + typeObject.Numer_Zamowienia.ToString());
                }

                lastData.Close();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
