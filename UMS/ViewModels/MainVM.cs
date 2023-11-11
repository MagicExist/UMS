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

        public object currentView 
        {
            get { return _currentView; }
            set { _currentView = value; OnpropertyChanged(); }
        }

        internal LoginStore LoginStore { get => _loginStore; set => _loginStore = value; }

        public void OnLoginAllowSub(object newView,User currentUser) 
        {
            currentView = newView;
        }

        public MainVM()
        {
            
        }
    }
}
