using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project7.Models
{
    public class UserWork
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }

    }
}