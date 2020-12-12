using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project7.Models
{
    public class Purchase
    {
        public int Id { set; get; }
        public string NameOfPurchases { get; set; }
        public int Price { get; set; }
        public  DateTime Date { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}