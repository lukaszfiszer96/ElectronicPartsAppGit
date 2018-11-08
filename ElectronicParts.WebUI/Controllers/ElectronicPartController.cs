using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicParts.Domain.Abstract;
using ElectronicParts.Domain.Entities;
using ElectronicParts.WebUI.Models;

namespace ElectronicParts.WebUI.Controllers
{
    public class ElectronicPartController : Controller
    {
        private IElectronicPartRepository repository;
        // GET: Resistor

        public ElectronicPartController(IElectronicPartRepository electrRepo)
        {
            this.repository = electrRepo;
        }

        public ViewResult List(string category, decimal ? resistance)
        {
            ElectronicPartViewModel model = new ElectronicPartViewModel
            {
                EleParts = repository.ElectronicParts
                .Where(p => category == null || p.Category == category)
                .Where(p => resistance == null || p.Value == resistance),
                //ElectronicRepo = repository.ElectronicParts
            };
            return View(model);

        }
    }
}