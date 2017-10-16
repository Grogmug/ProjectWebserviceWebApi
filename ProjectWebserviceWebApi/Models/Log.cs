using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectWebServiceWebApi.Models
{
    [Serializable]
    public class Log
    {
        private string time;
        private string id;
        private string alert;
        private string name;
        private string department;
        private string resident;
        private string registered;

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Alert
        {
            get { return alert; }
            set { alert = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public string Resident
        {
            get { return resident; }
            set { resident = value; }
        }
        public string Registered
        {
            get { return registered; }
            set { registered = value; }
        }

        public Log(string[] logArray)
        {
            Time = logArray[0];
            Id = logArray[1];
            Alert = logArray[2];
            Name = logArray[3];
            Department = logArray[4];
            Resident = logArray[5];
            Registered = logArray[7];
        }
    }
}