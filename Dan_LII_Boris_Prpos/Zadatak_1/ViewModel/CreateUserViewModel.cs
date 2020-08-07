using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.View;
using Zadatak_1.Model;
using Zadatak_1.Command;
using System.Windows;
using System.Windows.Input;

namespace Zadatak_1.ViewModel
{
    class CreateUserViewModel : ViewModelBase
    {
        CreateUser createUser;
        Entity context = new Entity();

        public CreateUserViewModel(CreateUser createUserOpen)
        {
            createUser = createUserOpen;
            User = new tblUser();
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value;
                OnPropertyChanged("LastName");
            }
        }


        private tblUser user;

        public tblUser User
        {
            get { return user; }
            set { user = value;
                OnPropertyChanged("User");
            }
        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        private void SaveExecute()
        {
            try
            {
                tblUser newUser = new tblUser();
                newUser.Fullname = FirstName + " " + LastName;
                newUser.Adress = User.Adress;
                newUser.Phone = User.Phone;
                newUser.Username = User.Username;
                newUser.Pasword = User.Pasword;
                newUser.NumberOfOrders = 0;
                if (ValidateCredentials(newUser.Username,newUser.Pasword)==true)
                {
                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    MessageBox.Show("User is created");
                    User = new tblUser();
                    FirstName = "";
                    LastName = "";
                }
                else
                {
                    MessageBox.Show("Username ans password must be unique");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(User.Phone) || String.IsNullOrEmpty(User.Adress) || String.IsNullOrEmpty(User.Pasword) || String.IsNullOrWhiteSpace(User.Username))
            {
                return false;
            }
            else
            {
                return true;
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
            createUser.Close();
        }
        private bool CanCloseExecute()
        {
            return true;
        }

        private bool ValidateCredentials(string user,string pas)
        {
            List<tblUser> userList = context.tblUsers.ToList();

            List<string> usernames = new List<string>();
            List<string> paswords = new List<string>();

            foreach (tblUser item in userList)
            {
                usernames.Add(item.Username);
                paswords.Add(item.Pasword);
            }

            if (!usernames.Contains(user) && !paswords.Contains(pas))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
