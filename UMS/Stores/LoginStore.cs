using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Models.UsersModels;

namespace UMS.Stores
{
    internal class LoginStore
    {
        public event Action<object,User> OnLoginAllow;
        public void OnLoginAllowInvoke(object newView,User currentUser) 
        {
            OnLoginAllow?.Invoke(newView,currentUser);
        }
    }
}
