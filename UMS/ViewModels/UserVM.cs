using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMS.Core;

namespace UMS.ViewModels
{
    internal class UserVM : ObservableObjects
    {
        #region variables for interface management
        private object _currentChildren;
        private Visibility _supportVisibility;
        private Visibility _searchVisibility;

        public Visibility SupportVisibility
        {
            get { return _supportVisibility; }
            set { _supportVisibility = value; OnpropertyChanged(); }
        }

        public Visibility SearchVisibility
        {
            get { return _searchVisibility; }
            set { _searchVisibility = value; OnpropertyChanged(); }
        }

        public object CurrentChildren
        {
            get { return _currentChildren; }
            set { _currentChildren = value; OnpropertyChanged(); }
        }
        #endregion

        public UserVM()
        {

        }

        #region Execute Methods
        public void ViewNavCollapse() 
        {
            SearchVisibility = Visibility.Collapsed;
        }
        public void AdminViewNavCollapse() 
        {
            SupportVisibility = Visibility.Collapsed;
        }
        #endregion
    }
}
