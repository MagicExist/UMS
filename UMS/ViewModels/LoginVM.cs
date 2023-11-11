using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;
using UMS.Models.ModelsDB;
using UMS.Models.UsersModels;
using UMS.Stores;

namespace UMS.ViewModels
{
    internal class LoginVM : ObservableObjects
    {
        private string _txtBoxUser;
        private string _txtBoxPassword;

        private LoginStore _loginStore;
        private UserVM _userVM;
        private UserSupportVM _userSupportVM;
        private userHomeVM _userHomeVM;

        public RelayCommand AllowAccess { get; set; }

        enum userType 
        {
            Admin = 1,
            Professor = 2,
            Student = 3
        }

        public string TxtBoxUser
        {
            get { return _txtBoxUser; }
            set { _txtBoxUser = value; OnpropertyChanged(nameof(TxtBoxUser)); }
        }

        public string TxtBoxPassword
        {
            get { return _txtBoxPassword; }
            set { _txtBoxPassword = value; OnpropertyChanged(nameof(TxtBoxPassword)); }
        }

        internal LoginStore LoginStore { get => _loginStore; set => _loginStore = value; }
        internal UserVM UserVM { get => _userVM; set => _userVM = value; }
        internal UserSupportVM UserSupportVM { get => _userSupportVM; set => _userSupportVM = value; }
        internal userHomeVM UserHomeVM { get => _userHomeVM; set => _userHomeVM = value; }

        public void AllowMethod(object parameter)
        {
            OpenDbConnection openDbConnection = new OpenDbConnection();
            LoginDB loginDB = new LoginDB();
            SqlConnection currentConnection = openDbConnection.openConnection();
            (User currentUser,int type) = loginDB.allowLogin(currentConnection,TxtBoxUser,TxtBoxPassword);

            switch ((userType)type) 
            {
                case userType.Student:
                    UserVM.CurrentChildren = UserHomeVM;
                    LoginStore.OnLoginAllowInvoke(UserVM,currentUser);
                    break;
            }
            currentConnection.Close();
        }

        public LoginVM()
        {
            AllowAccess = new RelayCommand(AllowMethod);
        }

    }
}
