using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.Models
{
    public class ClassRoom
    {
        string code;
        string topic;
        int capacity;
        string status;
        string software;

        public string Code { get => code; }
        public string Topic { get => topic; }
        public int Capacity { get => capacity; }
        public string Software { get => software; }
        public string Status { get => status; }

        public ClassRoom(string code, string topic, int capacity, string status, string software)
        {
            this.code = code;
            this.topic = topic;
            this.capacity = capacity;
            this.status = status;
            this.software = software;
        }

    }
}
