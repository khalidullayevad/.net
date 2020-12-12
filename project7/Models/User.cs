using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace project7.Models
{
    public class User
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
       
        public string Login { get; set; }

       
        public string Password { get; set; }
        public ICollection<Borrow> Borrows { get; set; }

        public ICollection<Debt> Debts { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public ICollection<Profit> Profits { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<UserDeposit> UserDeposits { get; set; }
        public ICollection<UserWork> UserWorks { get; set; }
        public User()
        {
            Borrows = new List<Borrow>();
            Debts = new List<Debt>();
            Payments = new List<Payments>();
            Profits = new List<Profit>();
            Purchases = new List<Purchase>();
            UserDeposits = new List<UserDeposit>();
            UserWorks = new List<UserWork>();
        }





}
}