using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ElectronicParts.Domain.Entities
{
    public class ElectronicPart
    {
        [HiddenInput(DisplayValue = false)]
        public int ElectronicPartID { get; set; }

        public string Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue,ErrorMessage ="Podaj wartość elementu")]
        [Display(Name="Wartośc elementu")]
        public decimal  Value { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Podaj cene elementu")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Podaj moc")]
        [Display(Name = "Dopuszczalna moc")]
        public int MaxPower { get; set; }


        [Display(Name = "Nazwa elementu")]
        [Required(ErrorMessage ="Podaj nazwe elementu !")]
        public string Name { get; set; }
    }
}
