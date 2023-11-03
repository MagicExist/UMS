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
        private DashBoardStudentVM _dashBoardStudentVM;

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
        internal DashBoardStudentVM DashBoardStudentVM { get => _dashBoardStudentVM; set => _dashBoardStudentVM = value; }

        public void AllowMethod(object parameter)
        {
            LoginStore.OnLoginAllowInvoke(_dashBoardStudentVM);
        }

        public LoginVM()
        {
            AllowAccess = new RelayCommand(AllowMethod);
        }

    }
}
