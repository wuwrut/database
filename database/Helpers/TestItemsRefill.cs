using database.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace database.Helpers
{
    class TestItemsRefill
    {
        public void TestItemsFill(IList<String> testItems, String tableName, String attrName)
        {
            DatabaseModel DataModel = new DatabaseModel();

            if(testItems == null)
            {
                testItems = new List<String>();
            }

            testItems.Clear();

            //IList<String> testItems = new List<String>();

            try
            {
                switch (tableName)
                {
                    case ("Bron"):
                        switch (attrName)
                        {
                            case ("Numer_Seryjny"):
                                foreach (Bron b in DataModel.Query<Bron>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Numer_Seryjny.ToString());
                                }
                                break;
                            case ("Nazwa"):
                                foreach (Bron b in DataModel.Query<Bron>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nazwa);
                                }
                                break;
                            case ("Cena"):
                                foreach (Bron b in DataModel.Query<Bron>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Cena.ToString());
                                }
                                break;
                            case ("PRODUKCJA_Numer_Produkcyjny"):
                                foreach (Bron b in DataModel.Query<Bron>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.PRODUKCJA_Numer_Produkcyjny.ToString());
                                }
                                break;
                            case ("KATEGORIA_ID"):
                                foreach (Bron b in DataModel.Query<Bron>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.KATEGORIA_ID.ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Amunicja"):
                        switch (attrName)
                        {
                            case ("Numer_Pudelka"):
                                foreach (Amunicja b in DataModel.Query<Amunicja>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Numer_Pudelka.ToString());
                                }
                                break;
                            case ("Kaliber"):
                                foreach (Amunicja b in DataModel.Query<Amunicja>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Kaliber);
                                }
                                break;
                            case ("Ilosc_Amunicji"):
                                foreach (Amunicja b in DataModel.Query<Amunicja>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Ilosc_Amunicji.ToString());
                                }
                                break;
                            case ("Cena"):
                                foreach (Amunicja b in DataModel.Query<Amunicja>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Cena.ToString());
                                }
                                break;
                            case ("PRODUKCJA_Numer_Produkcji"):
                                foreach (Amunicja b in DataModel.Query<Amunicja>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.PRODUKCJA_Numer_Produkcji.ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Hurtowe"):
                        switch (attrName)
                        {
                            case ("Numer_Zamowienia"):
                                foreach (Hurtowe b in DataModel.Query<Hurtowe>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Numer_Zamowienia.ToString());
                                }
                                break;
                            case ("Zezwolenie_Na_Handel"):
                                foreach (Hurtowe b in DataModel.Query<Hurtowe>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Zezwolenie_Na_Handel);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Detaliczne"):
                        switch (attrName)
                        {
                            case ("Numer_Zamowienia"):
                                foreach (Detaliczne b in DataModel.Query<Detaliczne>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Numer_Zamowienia.ToString());
                                }
                                break;
                            case ("Zezwolenie_Na_Bron"):
                                foreach (Detaliczne b in DataModel.Query<Detaliczne>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Zezwolenie_Na_Bron);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Dostawa"):
                        switch (attrName)
                        {
                            case ("Nr_Dostawy"):
                                foreach (Dostawa b in DataModel.Query<Dostawa>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nr_Dostawy.ToString());
                                }
                                break;
                            case ("Nazwa_dostawcy"):
                                foreach (Dostawa b in DataModel.Query<Dostawa>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nazwa_dostawcy);
                                }
                                break;
                            case ("Koszt_Calkowity"):
                                foreach (Dostawa b in DataModel.Query<Dostawa>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Koszt_Calkowity.ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Kategoria"):
                        switch (attrName)
                        {
                            case ("ID"):
                                foreach (Kategoria b in DataModel.Query<Kategoria>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.ID.ToString());
                                }
                                break;
                            case ("Nazwa"):
                                foreach (Kategoria b in DataModel.Query<Kategoria>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nazwa);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Material"):
                        switch (attrName)
                        {
                            case ("ID"):
                                foreach (Material b in DataModel.Query<Material>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.ID.ToString());
                                }
                                break;
                            case ("Nazwa"):
                                foreach (Material b in DataModel.Query<Material>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nazwa);
                                }
                                break;
                            case ("Ilosc"):
                                foreach (Material b in DataModel.Query<Material>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Ilosc.ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Pracownik"):
                        switch (attrName)
                        {
                            case ("PESEL"):
                                foreach (Pracownik b in DataModel.Query<Pracownik>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.PESEL.ToString());
                                }
                                break;
                            case ("Imie"):
                                foreach (Pracownik b in DataModel.Query<Pracownik>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Imie);
                                }
                                break;
                            case ("Nazwisko"):
                                foreach (Pracownik b in DataModel.Query<Pracownik>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nazwisko);
                                }
                                break;
                            case ("Zaswiadczenie_O_Niekaralnosci"):
                                foreach (Pracownik b in DataModel.Query<Pracownik>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Zaswiadczenie_O_Niekaralnosci);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Produkcja"):
                        switch (attrName)
                        {
                            case ("Numer_Produkcyjny"):
                                foreach (Produkcja b in DataModel.Query<Produkcja>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Numer_Produkcyjny.ToString());
                                }
                                break;
                            case ("Nazwa_Produktu"):
                                foreach (Produkcja b in DataModel.Query<Produkcja>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nazwa_Produktu);
                                }
                                break;
                            case ("Ilosc_Produktu"):
                                foreach (Produkcja b in DataModel.Query<Produkcja>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Ilosc_Produktu.ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("Zamowienie"):
                        switch (attrName)
                        {
                            case ("Numer_Zamowienia"):
                                foreach (Zamowienie b in DataModel.Query<Zamowienie>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Numer_Zamowienia.ToString());
                                }
                                break;
                            case ("Data_Dostawy"):
                                foreach (Zamowienie b in DataModel.Query<Zamowienie>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Data_Dostawy.ToString());
                                }
                                break;
                            case ("Data_Zamowienia"):
                                foreach (Zamowienie b in DataModel.Query<Zamowienie>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Data_Zamowienia.ToString());
                                }
                                break;
                            case ("Uwagi"):
                                foreach (Zamowienie b in DataModel.Query<Zamowienie>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Uwagi);
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("BRON_W_MAGAZYNIE"):
                        switch (attrName)
                        {
                            case ("Nazwa_Broni"):
                                foreach (User_Bron b in DataModel.Query<User_Bron>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nazwa_Broni.ToString());
                                }
                                break;
                            case ("Cena"):
                                foreach (User_Bron b in DataModel.Query<User_Bron>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Cena.ToString());
                                }
                                break;
                            case ("Kategoria"):
                                foreach (User_Bron b in DataModel.Query<User_Bron>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Kategoria.ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    case ("AMUNICJA_W_MAGAZYNIE"):
                        switch (attrName)
                        {
                            case ("Nazwa"):
                                foreach (User_Ammo b in DataModel.Query<User_Ammo>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Nazwa.ToString());
                                }
                                break;
                            case ("Cena"):
                                foreach (User_Ammo b in DataModel.Query<User_Ammo>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Cena.ToString());
                                }
                                break;
                            case ("Sztuk_w_pudelku"):
                                foreach (User_Ammo b in DataModel.Query<User_Ammo>("SELECT " + attrName + " FROM " + tableName))
                                {
                                    testItems.Add(b.Sztuk_w_pudelku.ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;                        
                }
                
                //return testItems;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //IList<String> nothing = new List<String>();
                //return nothing;
            }
        }
    }
}
