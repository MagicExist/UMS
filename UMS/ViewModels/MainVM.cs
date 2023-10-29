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

        private string _txtBoxUser;

        public string TxtBoxUser
        {
            get { return _txtBoxUser; }
            set { _txtBoxUser = value; OnpropertyChanged(nameof(TxtBoxUser)); }
        }

        public RelayCommand AllowStudentAcces { get; set; }

        public object currentView 
        {
            get { return _currentView; }
            set { _currentView = value; OnpropertyChanged(); }
        }

        public void AllowStuentAccesMethod(object parameter) 
        {
            currentView = _dashBoardStudentVM = new DashBoardStudentVM();   
        }

        public MainVM()
        {
            currentView = _loginVM = new LoginVM();
            AllowStudentAcces = new RelayCommand(AllowStuentAccesMethod);
            TxtBoxUser = "Test";
        }
    }
}
