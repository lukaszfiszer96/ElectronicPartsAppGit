using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElectronicParts.WebUI.Models
{
    public class LoginViewModel
    {   
        [Required(ErrorMessage ="Podaj nazwe uzytkownika.")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Prosz podaj hasło.")]
        [DataType(DataType.Password)]
        public string Passsword { get; set; }

    }
}