using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace UMS.Models.UsersModels
{
    internal class Professor : User
    {
        private int _state;
        private string _expertiseArea;

        public int State { get => _state; set => _state = value; }
        public string ExpertiseArea { get => _expertiseArea; set => _expertiseArea = value; }

        public Professor(string document, string name,int state, string expertiseArea, string email, string password) : base(document, name, email, password)
        {
            _expertiseArea = expertiseArea;
            _state = state;
        }
    }
}
