using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models.UsersModels
{
    internal class User
    {
        private readonly string _document;
        private readonly string _name;
        private readonly string _email;
        private readonly string _password;

        public string Document => _document;

        public string Name => _name;

        public string Email => _email;

        public string Password => _password;

        public User(string document, string name, string email, string password)
        {
            _document = document;
            _name = name;
            _email = email;
            _password = password;
        }

    }
}
