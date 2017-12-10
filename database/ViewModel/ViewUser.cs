using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using database.models;
using database.Helpers;

namespace database.ViewModel
{
    class ViewUser : ViewMainWindow
    {
        public RelayCommand ShowDataCommand { get; set; }

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

        public ViewUser()
        {
            ShowDataCommand = new RelayCommand(DataCommand); 
        }

        void DataCommand(object parameter)
        {
            ShowData DataWindow = new ShowData(TextBox1);
            DataWindow.Show();
        }
    }
}
