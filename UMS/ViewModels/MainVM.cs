using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UMS.Core;
using UMS.Models.UsersModels;
using UMS.Stores;

namespace UMS.ViewModels
{
    internal class MainVM : ObservableObjects
    {
        private object _currentView;

        private LoginStore _loginStore;

        private UserVM _userVM;
        private LoginVM _loginVM;

        public RelayCommand LogOutCommand { get; set; }

        public object currentView 
        {
            get { return _currentView; }
            set { _currentView = value; OnpropertyChanged(); }
        }

        internal LoginStore LoginStore { get => _loginStore; set => _loginStore = value; }
        internal UserVM UserVM { get => _userVM; set => _userVM = value; }
        internal LoginVM LoginVM { get => _loginVM; set => _loginVM = value; }
        

        public void OnLoginAllowSub(object newView,User currentUser) 
        {
            currentView = newView;
        }

        public MainVM()
        {
            LogOutCommand = new RelayCommand(LogOutMethod);
        }

        public void LogOutMethod(object parameter) 
        {
            UserVM.CurrentChildren = LoginVM;
            currentView = UserVM;
        }
    }
}
