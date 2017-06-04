using Donate4Life.Models;
using Donate4Life.Services;
using System.Linq;
using System.Web.Mvc;

namespace Donate4Life.Controllers
{
    public class DonorController : Controller
    {
        [HttpGet]
        public ActionResult AddNewDonor()
        {
            var donor = new Donor();

            return View(donor);
        }

        [HttpPost]
        public ActionResult AddNewDonor(Donor donor)
        {
            if (ModelState.IsValid)
            {
                var donorService = new DonorService();
                donorService.AddNewDonor(donor);

                TempData["successAddDonor"] = "Успешно добавяне на донор!";
            }

            return View(donor);
        }

        [HttpGet]
        public ActionResult EditDonor(int id)
        {
            Donors donor = null;
            using (var context = new Donate4LifeEntities1())
            {
                donor = context.Donors.FirstOrDefault(s => s.Id == id);
            }

            if (donor == null)
            {
                ModelState.AddModelError("", "Донорът не съществува.");
                return View(new Donor());
            }

            return View(new Donor
            {
                Age = donor.Age,
                Description = donor.Description,
                EyeColor = donor.EyeColor,
                HairColor = donor.HairColor,
                Height = donor.Height,
                Kilous = donor.Kilos,
                Town = donor.Town,
                Id = donor.Id
            });
        }

        [HttpPost]
        public ActionResult EditDonor(Donor donor)
        {
            if (ModelState.IsValid)
            {

                using (var context = new Donate4LifeEntities1())
                {
                    var donorForEdit = context.Donors.FirstOrDefault(s => s.Id == donor.Id);

                    donorForEdit.HairColor = donor.HairColor;
                    donorForEdit.Height = donor.Height;
                    donorForEdit.Kilos = donor.Kilous;
                    donorForEdit.Town = donor.Town;
                    donorForEdit.EyeColor = donor.EyeColor;
                    donorForEdit.Age = donor.Age;
                    donorForEdit.Description = donorForEdit.Description;
                    donorForEdit.Id = donor.Id;

                    context.SaveChanges();
                }
                TempData["successEditDonor"] = "Промените са запазени!";
            }

            return View(donor);
        }
        
        public ActionResult DeleteDonor(int id)
        {
            using (var context = new Donate4LifeEntities1())
            {
                var donor = context.Donors.FirstOrDefault(s=>s.Id == id);

                if (donor == null)
                {
                    TempData["errorDeleteDonor"] = "Донорът не съществува!";
                    return View("~/Views/Donor/EditDonor.cshtml", new Donor { Id=id});
                }
                context.Donors.Remove(donor);
                context.SaveChanges();

                TempData["succesDeleteDonor"] = "Донорът е изтрит успешно!";
                return View("~/Views/Donor/EditDonor.cshtml",new Donor());
            }
        }
    }
}