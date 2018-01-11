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
    class ViewAdmin : ViewMainWindow
    {
        public RelayCommand ShowDataCommand { get; set; }
        public RelayCommand ExecuteCommand { get; set; }

        public ViewAdmin()
        {
            ShowDataCommand = new RelayCommand(DataCommand);
            ExecuteCommand = new RelayCommand(Execute);
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

        }
    }
}
