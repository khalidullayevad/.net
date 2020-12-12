using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project7.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string NameOfStatus { get; set; }
        public int Salary { get; set; }
        public ICollection<UserWork> UserWorks { get; set; }
        public Status()
        {
            UserWorks = new List<UserWork>();
        }
    }
}