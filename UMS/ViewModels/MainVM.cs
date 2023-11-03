using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UMS.Core;
using UMS.Stores;

namespace UMS.ViewModels
{
    internal class MainVM : ObservableObjects
    {
        private object _currentView;
        private DashBoardStudentVM _dashBoardStudentVM;

        private LoginVM _loginVM;
        private LoginStore _loginStore;

        

        public object currentView 
        {
            get { return _currentView; }
            set { _currentView = value; OnpropertyChanged(); }
        }

        internal LoginVM LoginVM { get => _loginVM; set => _loginVM = value; }
        internal LoginStore LoginStore { get => _loginStore; set => _loginStore = value; }

        public void OnLoginAllowSub(object newView) 
        {
            currentView = newView;
        }


        public MainVM()
        {
            currentView = _loginVM = new LoginVM();
            
        }
       
    }
}
