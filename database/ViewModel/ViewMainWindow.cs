using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using database.models;
using database.Helpers;

namespace database.ViewModel
{
    class ViewMainWindow : ViewBase
    {
        public ObservableCollection<UserModel> LoginNames { get; set; }
        public RelayCommand LoginCommand { get; set; }

        object _SelectedLoginName;
        public object SelectedLoginName
        {
            get
            {
                return _SelectedLoginName;
            }
            set
            {
                if (_SelectedLoginName != value)
                {
                    _SelectedLoginName = value;
                    RaisePropertyChanged("SelectedLoginName");
                }
            }
        }

        public ViewMainWindow()
        {
            LoginNames = new ObservableCollection<UserModel>
            {
                new UserModel {Name = "User", Id = 0},
                new UserModel {Name = "Admin", Id = 1},
                new UserModel {Name = "Accountant", Id = 2}
            };
            SelectedLoginName = LoginNames[0];
            LoginCommand = new RelayCommand(LoginAsUser);
        }

        void LoginAsUser(object selectedItem)
        {
            var user = selectedItem as UserModel;

            switch (user.Name)
            {
                case "Admin":
                    Admin newAdminWindow = new Admin();
                    newAdminWindow.Show();
                    break;
                case "Accountant":
                    Accountant newAccountantWindow = new Accountant();
                    newAccountantWindow.Show();
                    break;
                default:
                    User newUserWindow = new User();
                    newUserWindow.Show();
                    break;
            }
            //Works, for testing it's disabled.
            //CloseWindow();
        }
    }
}
