using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace project7.Models
{
    public class ProjectContext : DbContext
    {   
    
        public DbSet<User> Users { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<UserDeposit> Deposits { set; get; }
        public DbSet<UserWork> Works { set; get; }
        public DbSet<Borrow> Borrows { set; get; }
        public DbSet<Payments> Payments { set; get; }
        public DbSet<Profit> Profits { set; get; }
        public DbSet<Debt> Debts { set; get; }
    }
}