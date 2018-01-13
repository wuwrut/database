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
        public RelayCommand AddWorkerCommand { get; set; }
        public RelayCommand AddWeaponCommand { get; set; }
        public RelayCommand AddAmmoCommand { get; set; }

        public ViewAccountant()
        {
            DatabaseModel DataModel = new DatabaseModel();
            // NULL POINTER EXCPETION ->Decimal licz = DataModel.TotalOutcome();
            AddWorkerCommand = new RelayCommand(AddWorker);
            AddWeaponCommand = new RelayCommand(AddWeapon);
            AddAmmoCommand = new RelayCommand(AddAmmo);

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
    }
}
