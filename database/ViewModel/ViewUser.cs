using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using database.models;
using database.Helpers;
using System.Collections;
using System.Collections.Generic;

namespace database.ViewModel
{

    public class TableNames
    {
        public string Name { get; set; }
        public ICollection<Attributes> TableAttributes { get; set; }
    }

    public class Attributes
    {
        public string Name { get; set; }
    }

    class ViewUser : ViewMainWindow
    {
        public RelayCommand ShowDataCommand { get; set; }
        public ObservableCollection<dynamic> Tables { get; set; }
        public ObservableCollection<dynamic> DataSet { get; set; }

        public ViewUser()
        {
            this.TableNamesFromDatabase = new List<TableNames>()
            {
                new TableNames(){Name="BRON", TableAttributes = new List<Attributes>
                    {
                        
                    }
                }
            };
            ShowDataCommand = new RelayCommand(DataCommand);
        }

        public IList<TableNames> TableNamesFromDatabase
        {
            get;
            private set;
        }

        public ICollection<Attributes> AttributesFromTable
        {
            get;
            private set;
        }

        private TableNames _SelectedTableName;
        public TableNames SelectedTableName
        {
            get
            {
                return _SelectedTableName;
            }
            set
            {
                if (_SelectedTableName != value)
                {
                    _SelectedTableName = value;
                    RaisePropertyChanged("SelectedTableName");
                    this.AttributesFromTable = _SelectedTableName.TableAttributes;
                    RaisePropertyChanged("AttributesFromTable");
                }
            }
        }

        private Attributes SelectedAttribute { get; set; }

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
            IEnumerable Table = DataModel.Query("SELECT * FROM BRON");
            
            //ShowData DataWindow = new ShowData();
            //DataWindow.Show();
        }
    }
}
