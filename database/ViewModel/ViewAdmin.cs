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
    class ViewAdmin : ViewBase
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
        public TableAttribute SelectedAttribute { get; set; }

        public RelayCommand ShowDataCommand { get; set; }
        public RelayCommand ExecuteCommand { get; set; }

        public ViewAdmin()
        {
            DatabaseModel DataModel = new DatabaseModel();

            this.TableNamesFromDatabase = new List<TableNames>()
            {
                new TableNames(){Name="Bron",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = ""},
                        new TableAttribute(){Name = "Nazwa"},
                        new TableAttribute(){Name = "Cena"}
                    }
                },

                new TableNames(){Name="Amunicja",
                    TableAttributes = new List<TableAttribute>()
                    {
                        new TableAttribute(){Name = ""},
                        new TableAttribute(){Name = "Kaliber"},
                        new TableAttribute(){Name = "Ilosc_amunicji"},
                        new TableAttribute(){Name = "Cena"}
                    }
                },

                new TableNames(){Name="Hurtowe", TableAttributes = new List<TableAttribute>(){}},

                new TableNames(){Name="Detaliczne", TableAttributes = new List<TableAttribute>(){}},

                new TableNames(){Name="Dostawa", TableAttributes = new List<TableAttribute>(){}},

                new TableNames(){Name="Kategoria", TableAttributes = new List<TableAttribute>(){}},

                new TableNames(){Name="Material", TableAttributes = new List<TableAttribute>(){}},

                new TableNames(){Name="Pracownik", TableAttributes = new List<TableAttribute>(){}},

                new TableNames(){Name="Produkcja", TableAttributes = new List<TableAttribute>(){}},

                new TableNames(){Name="Zamowienie", TableAttributes = new List<TableAttribute>(){}}

            };
            this.SelectedTableName = this.TableNamesFromDatabase[0];
            this.SelectedAttribute = this.TableAttributesFromDatabase[0];
            TextSearch = "";

            ShowDataCommand = new RelayCommand(DataCommand);
            ExecuteCommand = new RelayCommand(Execute);
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



        string _textInput;
        public string TextInput
        {
            get
            {
                return _textInput;
            }
            set
            {
                if (_textInput != value)
                {
                    _textInput = value;
                    RaisePropertyChanged("TextInput");
                }
            }
        }

        string _textOutput;
        public string TextOutput
        {
            get
            {
                return _textOutput;
            }
            set
            {
                if (_textOutput != value)
                {
                    _textOutput = value;
                    RaisePropertyChanged("TextOutput");
                }
            }
        }

        void Execute(object parameter)
        {
            DatabaseModel DataModel = new DatabaseModel();

            try
            {
                DataModel.Execute(TextInput);
            }
            catch (Exception e) 
            {
                TextOutput += e.Message + Environment.NewLine;
            }
        }

        void DataCommand(object parameter)
        {
            String que = "SELECT * FROM " + SelectedTableName.Name;

            if (SelectedAttribute.Name.Length > 0 && TextSearch.Length > 0)
            {

                que += " WHERE " + SelectedAttribute.Name + " LIKE \'%" + TextSearch + "%\' ";
            }

            DatabaseModel DataModel = new DatabaseModel();

            if (SelectedTableName.Name == "Bron")
            {
                IEnumerable<Bron> Table = DataModel.Query<Bron>(sql_query: que);
                ShowData DataWindow = new ShowData(Table, false);
                DataWindow.Show();
            }
            else
            {
                IEnumerable<Amunicja> Table = DataModel.Query<Amunicja>(sql_query: que);
                ShowData DataWindow = new ShowData(Table, false);
                DataWindow.Show();
            }
        }
    }
}
