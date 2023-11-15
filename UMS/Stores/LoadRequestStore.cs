using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.Models.UsersModels;

namespace UMS.Stores
{
    internal class LoadRequestStore
    {
        /// <summary>
        /// This event will send the current user in the session along with the user type, enabling the loading of their respective requests.
        /// </summary>
        public event Action<User,int> OnLoadRequest;
        /// <summary>
        /// Invokes the OnLoadRequest event, sending the current user in the session along with the user type.
        /// This enables the loading of requests specific to the user.
        /// </summary>
        /// <param name="currentUser">The current user in the session.</param>
        /// <param name="currentUserType">The type of the current user.</param>
        public void OnLoadRequestInvoke(User currentUser,int currentUserType) 
        {
            OnLoadRequest?.Invoke(currentUser,currentUserType);
        }
    }
}
