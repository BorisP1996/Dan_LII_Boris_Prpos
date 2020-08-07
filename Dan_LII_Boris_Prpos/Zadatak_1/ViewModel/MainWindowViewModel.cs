using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;
        Entity context = new Entity();

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        private void CloseExecute()
        {
            main.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }

        private ICommand login;
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(param => LoginExecute(), param => CanLoginExecute());
                }
                return login;
            }
        }
        private void LoginExecute()
        {
            try
            {
                List<tblUser> userList = context.tblUsers.ToList();

                List<string> usernames = new List<string>();
                List<string> paswords = new List<string>();

                foreach (tblUser item in userList)
                {
                    usernames.Add(item.Username);
                    paswords.Add(item.Pasword);
                }

                foreach (tblUser item in userList)
                {
                    if (item.Pasword==Password && item.Username==Username)
                    {
                        CreateOrder co = new CreateOrder(Username);
                        co.ShowDialog();
                    }
                }
                if (!usernames.Contains(Username)|| !paswords.Contains(Password))
                {
                    MessageBox.Show("Invalid parametres");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private bool CanLoginExecute()
        {
            if (String.IsNullOrEmpty(Username) || String.IsNullOrEmpty(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand user;
        public ICommand User
        {
            get
            {
                if (user == null)
                {
                    user = new RelayCommand(param => PatientExecute(), param => CanUserExecute());
                }
                return user;
            }
        }
        private void PatientExecute()
        {
            try
            {
                CreateUser createUser = new CreateUser();
                createUser.ShowDialog();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanUserExecute()
        {
            return true;
        }
    }
}
