﻿using System;
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

        public string Date { get => _date; }
        public string Subject { get => _subject; }
        public string Admin { get => _admin; }
        public string Status { get => _status; }
        public string Details { get => _details; }
        public string UserType { get => _userType;}
        public string UserDocument { get => _userDocument; }
        public string Reply { get => _reply; }

        public Request(string admin, string userType,string userDocument,string subject,string details,string status, string date, string reply)
        {
            _date = date;
            _subject = subject;
            _admin = admin;
            _status = status;
            _details = details;
            _userType = userType;
            _userDocument = userDocument;
            _reply = reply;
        }



    }
}
