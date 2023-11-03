using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Core;

namespace UMS.ViewModels
{
    internal class UserVM : ObservableObjects
    {
        private object _currentChildren;

        public object CurrentChildren 
        {
            get {  return _currentChildren; }
            set { _currentChildren = value; OnpropertyChanged(); }
        }

        public UserVM()
        {
            
        }
    }
}
