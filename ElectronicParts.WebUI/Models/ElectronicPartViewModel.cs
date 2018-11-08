using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ElectronicParts.Domain.Abstract;
using ElectronicParts.Domain.Entities;

namespace ElectronicParts.WebUI.Models
{
    public class ElectronicPartViewModel
    {
        [Display(Name = "Some Items")]   
        public IEnumerable<ElectronicPart> EleParts { get; set; }
        public IElectronicPartRepository ElectronicRepo { get; set; }
    }
}