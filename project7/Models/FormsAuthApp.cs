using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project7.Models
{
 
        public class LoginModel
        {
            [Required]
            public string login { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string password { get; set; }
        }

        public class RegisterModel
        {
            [Required]
            public string name { get; set; }

            [Required]
            public string surname { get; set; }

            [Required]
            public string login { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            public string ConfirmPassword { get; set; }

            [Required]
            public DateTime birthdate { get; set; }
        }
    }
