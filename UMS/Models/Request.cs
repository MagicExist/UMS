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
        string _userType;
        string _userDocument;
        string _reply;
        int _id;

        public string Date { get => _date; }
        public string Subject { get => _subject; }
        public string Admin { get => _admin; }
        public string Details { get => _details; }
        public string UserType { get => _userType;}
        public string UserDocument { get => _userDocument; }
        
        public int Id { get => _id;}
        public string Reply { get => _reply; set => _reply = value; }
        public string Status { get => _status; set => _status = value; }

        public Request(string admin, string userType, string userDocument, string subject, string details, string status, string date, string reply, int id)
        {
            _date = date;
            _subject = subject;
            _admin = admin;
            Status = status;
            _details = details;
            _userType = userType;
            _userDocument = userDocument;
            Reply = reply;
            _id = id;
        }

    }
}
