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
    class ViewAccountant
    {
        public RelayCommand AddWorkerCommand { get; set; }
        public RelayCommand AddProductionCommand { get; set; }
        public RelayCommand AddMaterialCommand { get; set; }

        public ViewAccountant()
        {
            AddWorkerCommand = new RelayCommand(AddWorker);
            AddProductionCommand = new RelayCommand(AddProduction);
            AddMaterialCommand = new RelayCommand(AddMaterial);
        }

        void AddWorker(object paramater)
        {
            AccountantForm AForm = new AccountantForm(0);
            AForm.Show();
        }

        void AddProduction(object paramater)
        {
            AccountantForm AForm = new AccountantForm(1);
            AForm.Show();
        }

        void AddMaterial(object paramater)
        {
            AccountantForm AForm = new AccountantForm(2);
            AForm.Show();
        }
    }
}
