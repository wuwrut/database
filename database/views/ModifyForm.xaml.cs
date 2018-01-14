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

        public ModifyForm(object toChange, int mode)
        {
            InitializeComponent();
            class_mode = mode;
            sthToChange = toChange;

            DatabaseModel DataModel = new DatabaseModel();

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

            if (mode == 1)
            {
                Bron typeObject = (Bron)toChange;
            }
            else if (mode == 2)
            {
                Amunicja typeObject = (Amunicja)toChange;
            }
            else if (mode == 3)
            {
                Hurtowe typeObject = (Hurtowe)toChange;
            }
            else if (mode == 4)
            {
                Detaliczne typeObject = (Detaliczne)toChange;
            }
            else if (mode == 5)
            {
                Dostawa typeObject = (Dostawa)toChange;
            }
            else if (mode == 6)
            {
                Kategoria typeObject = (Kategoria)toChange;
            }
            else if (mode == 7)
            {
                Material typeObject = (Material)toChange;
            }
            else if (mode == 8)
            {
                Pracownik typeObject = (Pracownik)toChange;
            }
            else if (mode == 9)
            {
                Produkcja typeObject = (Produkcja)toChange;
            }
            else
            {
                Zamowienie typeObject = (Zamowienie)toChange;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            object toChange = sthToChange;
            int mode = class_mode;

            if (mode == 1)
            {
                Bron typeObject = (Bron)toChange;
            }
            else if (mode == 2)
            {
                Amunicja typeObject = (Amunicja)toChange;
            }
            else if (mode == 3)
            {
                Hurtowe typeObject = (Hurtowe)toChange;
            }
            else if (mode == 4)
            {
                Detaliczne typeObject = (Detaliczne)toChange;
            }
            else if (mode == 5)
            {
                Dostawa typeObject = (Dostawa)toChange;
            }
            else if (mode == 6)
            {
                Kategoria typeObject = (Kategoria)toChange;
            }
            else if (mode == 7)
            {
                Material typeObject = (Material)toChange;
            }
            else if (mode == 8)
            {
                Pracownik typeObject = (Pracownik)toChange;
            }
            else if (mode == 9)
            {
                Produkcja typeObject = (Produkcja)toChange;
            }
            else
            {
                Zamowienie typeObject = (Zamowienie)toChange;
            }
        }

    }
}
