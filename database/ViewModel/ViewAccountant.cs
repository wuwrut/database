using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using database.models;
using database.Helpers;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace database.ViewModel
{
    class ViewAccountant : ViewBase
    {
        public class TableNames
        {
            public String Name { get; set; }
            public IList<TableAttribute> TableAttributes { get; set; }
        };

        public class TableAttribute
        {
            public string Name { get; set; }
        };


        public IList<TableNames> TableNamesFromDatabase { get; private set; }
        public IList<TableAttribute> TableAttributesFromDatabase { get; private set; }
        public IList<String> TestItems { get; set; }

        public RelayCommand ShowDataCommand { get; set; }
        public RelayCommand AddWorkerCommand { get; set; }
        public RelayCommand AddWeaponCommand { get; set; }
        public RelayCommand AddAmmoCommand { get; set; }
        public RelayCommand ListWorkersCommand { get; set; }
        public RelayCommand ListGunsCommand { get; set; }
        public RelayCommand ListAmmoCommand { get; set; }
        public RelayCommand GetAmmoCommand { get; set; }
        public RelayCommand GetOutcomeCommand { get; set; }

        public ViewAccountant()
        {
            // NULL POINTER EXCPETION ->Decimal licz = DataModel.TotalOutcome();
            AddWorkerCommand = new RelayCommand(AddWorker);
            AddWeaponCommand = new RelayCommand(AddWeapon);
            AddAmmoCommand = new RelayCommand(AddAmmo);
            ListWorkersCommand = new RelayCommand(ListWorkers);
            ListGunsCommand = new RelayCommand(ListGuns);
            ListAmmoCommand = new RelayCommand(ListAmmo);
            GetAmmoCommand = new RelayCommand(GetAmmo);
            GetOutcomeCommand = new RelayCommand(GetOutcome);

            this.TableNamesFromDatabase = new List<TableNames>()
            {
                new TableNames(){Name="Bron",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = "Numer_seryjny"},
                        new TableAttribute(){Name = "Nazwa"},
                        new TableAttribute(){Name = "Cena"},
                        new TableAttribute(){Name = "KATEGORIA_ID"},
                    }
                },

                new TableNames(){Name="Amunicja",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = "Numer_pudelka"},
                        new TableAttribute(){Name = "Kaliber"},
                        new TableAttribute(){Name = "Ilosc_amunicji"},
                        new TableAttribute(){Name = "Cena"}
                    }
                },

                new TableNames(){Name="Pracownik",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = "Pesel"},
                        new TableAttribute(){Name = "Imie"},
                        new TableAttribute(){Name = "Nazwisko"},
                        new TableAttribute(){Name = "Placa"},
                    }
                },

            };
            this.SelectedTableName = this.TableNamesFromDatabase[0];
            this.SelectedAttribute = this.TableAttributesFromDatabase[0];
            TextSearch = "";
            TextAmmo = "";
            TextOutcome = "";
            TestItems = new List<String>();

            try
            {
                DatabaseModel DataModel = new DatabaseModel();

                foreach (User_Bron b in DataModel.Query<User_Bron>("SELECT Nazwa_Broni FROM BRON_W_MAGAZYNIE"))
                {
                    TestItems.Add(b.Nazwa_Broni);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            ShowDataCommand = new RelayCommand(DataCommand);


        }

        private TableNames _selectedTableName;
        public TableNames SelectedTableName
        {
            get
            {
                return _selectedTableName;
            }
            set
            {
                if (_selectedTableName != value)
                {
                    _selectedTableName = value;
                    RaisePropertyChanged("SelectedTableName");
                    this.TableAttributesFromDatabase = _selectedTableName.TableAttributes;
                    this.SelectedAttribute = this.TableAttributesFromDatabase[0];
                    RaisePropertyChanged("TableAttributesFromDatabase");
                    RaisePropertyChanged("SelectedAttribute");

                    TestItemsRefill TestItemsInstance = new TestItemsRefill();
                    TestItemsInstance.TestItemsFill(this.TestItems, SelectedTableName.Name, SelectedAttribute.Name);
                }
            }
        }


        private TableAttribute _selectedAttribute;
        public TableAttribute SelectedAttribute
        {
            get
            {
                return _selectedAttribute;
            }
            set
            {
                if (_selectedAttribute != value)
                {
                    _selectedAttribute = value;
                    RaisePropertyChanged("SelectedAttribute");
                    if (_selectedAttribute == null && TableAttributesFromDatabase != null)
                    {
                        this.SelectedAttribute = this.TableAttributesFromDatabase[0];
                    }

                    TestItemsRefill TestItemsInstance = new TestItemsRefill();
                    TestItemsInstance.TestItemsFill(this.TestItems, SelectedTableName.Name, _selectedAttribute.Name);
                }
            }
        }

        string _textSearch;
        public string TextSearch
        {
            get
            {
                return _textSearch;
            }
            set
            {
                if (_textSearch != value)
                {
                    _textSearch = value;
                    RaisePropertyChanged("TextSearch");
                }
            }
        }

        void DataCommand(object parameter)
        {
            String que = "SELECT * FROM " + SelectedTableName.Name;

            if (SelectedAttribute.Name.Length > 0 && TextSearch.Length > 0)
            {

                que += " WHERE " + SelectedAttribute.Name + " LIKE \'%" + TextSearch.Replace(",", ".") + "%\' ";
            }

            DatabaseModel DataModel = new DatabaseModel();
            try
            {
                if (SelectedTableName.Name == "Bron")
                {
                    IEnumerable<Bron> Table = DataModel.Query<Bron>(sql_query: que);
                    ShowData DataWindow = new ShowData(Table, 0);
                    DataWindow.Show();
                }
                else if(SelectedTableName.Name == "Amunicja")
                {
                    IEnumerable<Amunicja> Table = DataModel.Query<Amunicja>(sql_query: que);
                    ShowData DataWindow = new ShowData(Table, 0);
                    DataWindow.Show();
                }
                else
                {
                    IEnumerable<Pracownik> Table = DataModel.Query<Pracownik>(sql_query: que);
                    ShowData DataWindow = new ShowData(Table, 0);
                    DataWindow.Show();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        string _textOutcome;
        public string TextOutcome
        {
            get
            {
                return _textOutcome;
            }
            set
            {
                if (_textOutcome != value)
                {
                    _textOutcome = value;
                    RaisePropertyChanged("TextOutcome");
                }
            }
        }

        string _textAmmo;
        public string TextAmmo
        {
            get
            {
                return _textAmmo;
            }
            set
            {
                if (_textAmmo != value)
                {
                    _textAmmo = value;
                    RaisePropertyChanged("TextAmmo");
                }
            }
        }

        void AddWorker(object parameter)
        {
            AccountantForm AForm = new AccountantForm(0);
            AForm.Show();
        }

        void AddAmmo(object parameter)
        {
            AccountantForm AForm = new AccountantForm(1);
            AForm.Show();
        }

        void AddWeapon(object parameter)
        {
            AccountantForm AForm = new AccountantForm(2);
            AForm.Show();
        }

        void ListWorkers(object parameter)
        {
            DatabaseModel DataModel = new DatabaseModel();

            try
            {
                IEnumerable<Pracownik> Table = DataModel.Query<Pracownik>("SELECT * FROM Pracownik");
                ShowData DataWindow = new ShowData(Table, 0);
                DataWindow.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void ListAmmo(object parameter)
        {
            DatabaseModel DataModel = new DatabaseModel();

            try
            {
                IEnumerable<Amunicja> Table = DataModel.Query<Amunicja>("SELECT * FROM Amunicja");
                ShowData DataWindow = new ShowData(Table, 0);
                DataWindow.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void ListGuns(object parameter)
        {
            DatabaseModel DataModel = new DatabaseModel();

            try
            {
                IEnumerable<Bron> Table = DataModel.Query<Bron>("SELECT * FROM Bron");
                ShowData DataWindow = new ShowData(Table, 0);
                DataWindow.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void GetAmmo(object parameter)
        {
            DatabaseModel DataModel = new DatabaseModel();

            try
            {
                TextAmmo = DataModel.TotalAmmoCount().ToString();                            
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void GetOutcome(object parameter)
        {
            DatabaseModel DataModel = new DatabaseModel();

            try
            {
                TextOutcome = DataModel.TotalOutcome().ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
