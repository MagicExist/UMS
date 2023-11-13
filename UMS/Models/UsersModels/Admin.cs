using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models.UsersModels
{
    internal class Admin : User
    {
        public Admin(string document, string name, string email, string password) : base(document, name, email, password)
        {

        }
    }
}
