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
        string _details;

        public string Date { get => _date; }
        public string Subject { get => _subject; }
        public string Admin { get => _admin; }
        public string Status { get => _status; }
        public string Details { get => _details; }

        public Request(string admin, string subject,string details,string status, string date)
        {
            _date = date;
            _subject = subject;
            _admin = admin;
            _status = status;
            _details = details;
        }



    }
}
