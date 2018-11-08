using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicParts.Domain.Abstract;


namespace ElectronicParts.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IElectronicPartRepository repo;
        public NavigationController(IElectronicPartRepository electroRepo)
        {
            repo = electroRepo;
        }

        // GET: Navigation
        public PartialViewResult Menu()
        {
            IEnumerable<string> dane = repo.ElectronicParts
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(dane);
        }
    }
}