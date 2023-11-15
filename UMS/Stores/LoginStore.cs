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

        /// <summary>
        /// This event will be used to switch the view between the loginVM and MainVM based on the current user.
        /// </summary>
        public event Action<object,User> OnLoginAllow;

        /// <summary>
        /// Invokes the OnLoginAllow event to switch the view between the loginVM and MainVM based on the current user.
        /// </summary>
        /// <param name="newView">The new view to be displayed.</param>
        /// <param name="currentUser">The current user triggering the view switch.</param>
        public void OnLoginAllowInvoke(object newView,User currentUser) 
        {
            OnLoginAllow?.Invoke(newView,currentUser);
        }
    }
}
