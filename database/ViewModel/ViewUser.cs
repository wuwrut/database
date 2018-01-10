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
            public ICollection<TableAttribute> TableAttributes { get; set; }
        };

        public class TableAttribute
        {
            public string Name { get; set; }
        };


        public RelayCommand ShowDataCommand { get; set; }
        public RelayCommand AddNewOrder { get; set; }
        public RelayCommand ListOrders { get; set; }

        public IList<TableNames> TableNamesFromDatabase { get; private set; }
        public ICollection<TableAttribute> TableAttributesFromDatabase { get; private set; }
        public TableAttribute SelectedAttribute { get; set; }

        public ViewUser()
        {
            this.TableNamesFromDatabase = new List<TableNames>()
            {
                new TableNames(){Name="BRON",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = ""},
                        new TableAttribute(){Name = "Nazwa"}
                    }
                },

                new TableNames(){Name="AMUNICJA",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = ""},
                        new TableAttribute(){Name = "Kaliber"},
                        new TableAttribute(){Name = "Ilosc amunicji"}
                    }
                }
            };
            this.SelectedTableName = this.TableNamesFromDatabase[0];    

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
                    RaisePropertyChanged("TableAttributesFromDatabase");
                }
            }
        }

        string _TextBox1;
        public string TextBox1
        {
            get
            {
                return _TextBox1;
            }
            set
            {
                if (_TextBox1 != value)
                {
                    _TextBox1 = value;
                    RaisePropertyChanged("TextBox1");
                }
            }
        }

        void DataCommand(object parameter)
        {
            DatabaseModel DataModel = new DatabaseModel();
            IEnumerable<dynamic> Table = DataModel.Query("SELECT * FROM BRON");

            //NOT WORKING!
            //ShowData DataWindow = new ShowData(Table, false);
            //DataWindow.Show();
        }

        void ListUserOrders(object paramater)
        {
            DatabaseModel DataModel = new DatabaseModel();
            IEnumerable<dynamic> Table = DataModel.Query("SELECT * FROM ZAMOWIENIE");

            //NOT WORKING!
            //ShowData DataWindow = new ShowData(Table, false);
            //DataWindow.Show();
        }

        void AddNewUserOrder(object paramter)
        {
            AddOrder newOrder = new AddOrder();
            newOrder.Show();
        }
    }
}
