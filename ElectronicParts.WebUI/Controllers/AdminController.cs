using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicParts.Domain.Abstract;
using ElectronicParts.Domain.Entities;

namespace ElectronicParts.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IElectronicPartRepository ElectronicRepo;

        public AdminController(IElectronicPartRepository repo)
        {
            ElectronicRepo = repo;
        }

        // GET: Admin
        public ViewResult Index()
        {
            return View(ElectronicRepo.ElectronicParts);
        }

        public ViewResult Edit(int ElectronicPartID)
        {
            ElectronicPart part = ElectronicRepo.ElectronicParts
                .FirstOrDefault(p => p.ElectronicPartID == ElectronicPartID);
            return View(part);
        }

        [HttpPost]
        public ActionResult Edit(ElectronicPart electronicPart)
        {
            if (ModelState.IsValid)
            {
                ElectronicRepo.SaveItem(electronicPart);
                TempData["message"] = string.Format("Zapiasano {0}", electronicPart.Category);
                return RedirectToAction("Index");
            }
            else
            {
                return View(electronicPart);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new ElectronicPart());
        }

        [HttpPost]
        public ActionResult Delete(int ElectronicPartID)
        {
            ElectronicPart deletedItem = ElectronicRepo.DeleteItem(ElectronicPartID);
            if (deletedItem != null)
            {
                TempData["message"] = string.Format("Usunieto {0}", deletedItem.Category);
                return RedirectToAction("Index");
            }
            else
                return View("Index");
            
        }

    }
}