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

    class ViewUser : ViewMainWindow
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


        public RelayCommand ShowDataCommand { get; set; }
        public RelayCommand AddNewOrder { get; set; }
        public RelayCommand ListOrders { get; set; }

        public IList<TableNames> TableNamesFromDatabase { get; private set; }
        public IList<TableAttribute> TableAttributesFromDatabase { get; private set; }
        public IList<String> TestItems { get; set; }

        public ViewUser()
        {
            this.TableNamesFromDatabase = new List<TableNames>()
            {
                new TableNames(){Name="BRON_W_MAGAZYNIE",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = "Nazwa_Broni"},
                        new TableAttribute(){Name = "Cena"},
                        new TableAttribute(){Name = "Kategoria"},

                    }
                },

                new TableNames(){Name="AMUNICJA_W_MAGAZYNIE",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = "Nazwa"},
                        new TableAttribute(){Name = "Cena"},
                        new TableAttribute(){Name = "Sztuk_w_pudelku"},
                    }
                }
            };
            this.SelectedTableName = this.TableNamesFromDatabase[0];
            this.SelectedAttribute = this.TableAttributesFromDatabase[0];
            TextSearch = "";
            TestItems = new List<String>();

            try
            {
                DatabaseModel DataModel = new DatabaseModel();

                foreach (Bron b in DataModel.Query<Bron>("SELECT Nazwa_Broni FROM BRON_W_MAGAZYNIE"))
                {
                    TestItems.Add(b.Nazwa);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            ShowDataCommand = new RelayCommand(DataCommand);

            ListOrders = new RelayCommand(ListUserOrders);
            AddNewOrder = new RelayCommand(AddNewUserOrder);            
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

            if(SelectedAttribute.Name.Length > 0 && TextSearch.Length > 0)
            {
                
                que += " WHERE " + SelectedAttribute.Name + " LIKE \'%" + TextSearch.Replace(",", ".") + "%\' ";
            }

            DatabaseModel DataModel = new DatabaseModel();
            try
            {
                if (SelectedTableName.Name == "BRON_W_MAGAZYNIE")
                {
                    IEnumerable<User_Bron> Table = DataModel.Query<User_Bron>(sql_query: que);
                    ShowData DataWindow = new ShowData(Table, 0);
                    DataWindow.Show();
                }
                else
                {
                    IEnumerable<User_Ammo> Table = DataModel.Query<User_Ammo>(sql_query: que);
                    ShowData DataWindow = new ShowData(Table, 0);
                    DataWindow.Show();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void ListUserOrders(object paramater)
        {
            DatabaseModel DataModel = new DatabaseModel();

            try
            {
                IEnumerable<Zamowienie> Table = DataModel.Query<Zamowienie>("SELECT * FROM ZAMOWIENIE");
                ShowData DataWindow = new ShowData(Table, 0);
                DataWindow.Show();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }                  
        }

        void AddNewUserOrder(object paramter)
        {
            AddOrder newOrder = new AddOrder();
            newOrder.Show();
        }
    }
}
