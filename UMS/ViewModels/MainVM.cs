using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UMS.Core;

namespace UMS.ViewModels
{
    internal class MainVM : ObservableObjects
    {
        private object _currentView;
        private DashBoardStudentVM _dashBoardStudentVM;
        private LoginVM _loginVM;

        

        public object currentView 
        {
            get { return _currentView; }
            set { _currentView = value; OnpropertyChanged(); }
        }

        public MainVM()
        {
            currentView = _loginVM = new LoginVM();
            
        }
    }
}
