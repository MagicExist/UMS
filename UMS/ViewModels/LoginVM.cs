using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;
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
        private AdminHomeVM _adminHomeVM;

        public RelayCommand AllowAccess { get; set; }


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
        internal AdminHomeVM AdminHomeVM { get => _adminHomeVM; set => _adminHomeVM = value; }

        public void AllowMethod(object parameter)
        {
            UserVM.CurrentChildren = AdminHomeVM;
            LoginStore.OnLoginAllowInvoke(UserVM);
        }

        public LoginVM()
        {
            AllowAccess = new RelayCommand(AllowMethod);
        }

    }
}
