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
        public event Action<User,int> OnLoadRequest;
        public void OnLoadRequestInvoke(User currentUser,int currentUserType) 
        {
            OnLoadRequest?.Invoke(currentUser,currentUserType);
        }
    }
}
