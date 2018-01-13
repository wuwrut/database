using System;
using System.Windows;
using System.Windows.Threading;
using System.Collections.ObjectModel;
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

            switch (user.Id)
            {
                case 1:
                    Admin newAdminWindow = new Admin();
                    newAdminWindow.Show();
                    break;
                case 2:
                    Accountant newAccountantWindow = new Accountant();
                    newAccountantWindow.Show();
                    break;
                default:
                    User newUserWindow = new User();
                    newUserWindow.Show();
                    break;
            }
            //CloseWindow();
        }
    }
}
