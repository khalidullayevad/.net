using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace project7.Models
{
    public class Debt
    {
        /*мои должники*/
        public int Id { set; get; }
        
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Remote("CheckName", "Debts", ErrorMessage = "Name is already in use.")]
        public string Debtor { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int AmountOfMoney { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime DateIssue { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public DateTime DateReturn { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public int? UserId { get; set; }
        public User User { get; set; }
        public Boolean Paid { get; set; }
    }
}