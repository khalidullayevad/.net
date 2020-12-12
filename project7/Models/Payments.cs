﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project7.Models
{
    public class Payments
    {
        public int Id { set; get; }
        public string Payment { get; set; }
        public int Price { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public Boolean Paid { get; set; }
    }
}