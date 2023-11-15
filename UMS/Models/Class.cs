using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    public class Class
    {
        string day;
        string startTime;
        string endTime;
        string idGroup;
        string idClassRoom;
        string course;
        string details;
        int id;
        public string StartTime { get => startTime;}
        public string EndTime { get => endTime; }
        public string IdGroup { get => idGroup; }
        public string IdClassRoom { get => idClassRoom; }
        public string Course { get => course; }

        public string Day { get => day;}
        public string Details { get => details; set => details = value; }
        public int Id { get => id; set => id = value; }

        public Class(string day, string startTime, string endTime, string idGroup, string idClassRoom, string course, string details, int id)
        {
            this.day = day;
            this.startTime = startTime;
            this.endTime = endTime;
            this.idGroup = idGroup;
            this.idClassRoom = idClassRoom;
            this.course = course;
            this.details = details;
            Id = id;    
        }

    }
}
