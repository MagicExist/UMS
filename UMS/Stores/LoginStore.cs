using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Stores
{
    internal class LoginStore
    {
        public event Action<object> OnLoginAllow;
        public void OnLoginAllowInvoke(object newView) 
        {
            OnLoginAllow?.Invoke(newView);
        }
    }
}
