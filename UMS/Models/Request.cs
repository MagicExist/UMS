using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    public class Request
    {
        string _date;
        string _subject;
        string _admin;
        string _status;

        public string Date { get => _date; }
        public string Subject { get => _subject; }
        public string Admin { get => _admin; }
        public string Status { get => _status; }

        public Request(string date, string subject, string admin, string status)
        {
            _date = date;
            _subject = subject;
            _admin = admin;
            _status = status;
        }



    }
}
