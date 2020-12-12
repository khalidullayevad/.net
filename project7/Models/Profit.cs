using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project7.Models
{
    /* прибыль*/
    public class Profit
    {
        public int Id { get; set; }
        public string NameOfProfit{ get; set; }

        public int AmountOfMoney { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}