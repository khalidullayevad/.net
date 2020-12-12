using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace project7.Models
{ 
    /*мои долги*/
    public class Borrow
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { set; get; }

        [Required]
        [Remote("CheckName", "Home", ErrorMessage = "Name is not valid.")]
        public string NameOfBorrow { get; set; }

        [Required]
        
        public int AmountOfMoney { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateIssue { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateReturn { get; set; }
        [Required]
        public int? UserId { get; set; }
        public User User { get; set; }
        [Required]
        public Boolean Paid { get; set; }

    }
}