using Donate4Life.Models;
using Donate4Life.Services;
using System;
using System.Collections.Generic;
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
        public ActionResult EditDonor(Donor donor)
        {
            return View(new Donor
            {
                Age = donor.Age,
                Description = donor.Description,
                EyeColor = donor.EyeColor,
                HairColor = donor.HairColor,
                Height = donor.Height,
                Kilous = donor.Kilous,
                Town = donor.Town,
                Id = donor.Id
            });
        }

        [HttpPost]
        public ActionResult EditDonor1(Donor donor)
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

            return View("~/Views/Donor/EditDonor.cshtml",donor);
        }

        public ActionResult DeleteDonor(int id)
        {
            using (var context = new Donate4LifeEntities1())
            {
                var donor = context.Donors.FirstOrDefault(s => s.Id == id);

                var fav = context.UsersFavourites.Where(s=>s.DonorId == id);

                foreach (var item in fav)
                {
                    context.UsersFavourites.Remove(item);
                }

                context.SaveChanges();

                if (donor == null)
                {
                    TempData["errorDeleteDonor"] = "Донорът не съществува!";
                    return View("~/Views/Donor/EditDonor.cshtml", new Donor { Id = id });
                }
                context.Donors.Remove(donor);
                context.SaveChanges();

                TempData["succesDeleteDonor"] = "Донорът е изтрит успешно!";
                return View("~/Views/Donor/SuccessDeletedDonor.cshtml", id);
            }
        }

        [HttpGet]
        public ActionResult ListAllDonors()
        {
            using (var context = new Donate4LifeEntities1())
            {
                var donors = context.Donors.ToList();

                var listDonors = new List<Donor>();

                foreach (var donor in donors)
                {
                    listDonors.Add(new Models.Donor
                    {
                        AddedDay = donor.AddedDate,
                        Age = donor.Age,
                        Description = donor.Description,
                        EyeColor = donor.EyeColor,
                        HairColor = donor.HairColor,
                        Height = donor.Height,
                        Id = donor.Id,
                        Kilous = donor.Kilos,
                        Town = donor.Town,
                        Views = donor.Views
                    });
                }

                return View(listDonors);
            }
        }

        [HttpGet]
        public ActionResult ListAllFilteredDonors()
        {

            var criterias = (Criterias)TempData["criterias"];

            using (var context = new Donate4LifeEntities1())
            {
                var donors = context.Donors.ToList();

                var searchService = new SearchByCriteriaService(donors);

                var filteredDonors = searchService.SearchByAge(criterias.Age)
                                                  .SearchByEyeColor(criterias.EyeColor)
                                                  .SearchByHairColor(criterias.HairColor)
                                                  .SearchByHeight(criterias.Height)
                                                  .SearchByWeight(criterias.Kilous)
                                                  .GetFilteredDonors();

                var listDonors = new List<Donor>();

                foreach (var donor in filteredDonors)
                {
                    listDonors.Add(new Models.Donor
                    {
                        AddedDay = donor.AddedDate,
                        Age = donor.Age,
                        Description = donor.Description,
                        EyeColor = donor.EyeColor,
                        HairColor = donor.HairColor,
                        Height = donor.Height,
                        Id = donor.Id,
                        Kilous = donor.Kilos,
                        Town = donor.Town,
                        Views = donor.Views
                    });
                }

                return View(listDonors);
            }
        }

        [HttpGet]
        public ActionResult ListAllOtherFilteredDonors()
        {
            var criterias = (Criterias)TempData["criterias"];

            using (var context = new Donate4LifeEntities1())
            {
                var donors = context.Donors.ToList();

                switch (criterias.OtherCriteria)
                {
                    case "Най-нови":
                        donors = donors.OrderByDescending(s => s.AddedDate).Take(10).ToList();
                        break;
                    case "Най-разглеждани":
                        donors = donors.OrderByDescending(s => s.Views).Take(10).ToList();
                        break;
                    case "Най-предпочитани":
                        donors = donors.OrderByDescending(s => s.Views).Take(10).ToList();
                        break;
                    default:
                        break;
                }

                var listDonors = new List<Donor>();

                foreach (var donor in donors)
                {
                    listDonors.Add(new Models.Donor
                    {
                        AddedDay = donor.AddedDate,
                        Age = donor.Age,
                        Description = donor.Description,
                        EyeColor = donor.EyeColor,
                        HairColor = donor.HairColor,
                        Height = donor.Height,
                        Id = donor.Id,
                        Kilous = donor.Kilos,
                        Town = donor.Town,
                        Views = donor.Views
                    });
                }

                return View(listDonors);
            }
        }

        [HttpGet]
        public ActionResult DonorDetails(Models.Donor donor)
        {
            using (var context = new Donate4LifeEntities1())
            {
                var don = context.Donors.FirstOrDefault(s=>s.Id == donor.Id);

                don.Views++;

                context.SaveChanges();
            }

            return View(donor);
        }

        [HttpGet]
        public ActionResult ListDonorsByCriteria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListDonorsByCriteria(Criterias criterias)
        {

                TempData["criterias"] = criterias;

                return RedirectToAction("ListAllFilteredDonors", "Donor");
            
        }

        [HttpGet]
        public ActionResult ListDonorsByOtherCriteria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListDonorsByOtherCriteria(Criterias criterias)
        {

            TempData["criterias"] = criterias;

            return RedirectToAction("ListAllOtherFilteredDonors", "Donor");

        }

        [HttpGet]
        public ActionResult SuccessDeletedDonor(int id)
        {
            return View(id);
        }
        
        
        public ActionResult RemoveDonorFromFavourites(Donor donor)
        {
            var userId = Convert.ToInt32(Session["UserId"]);

            using (var context = new Donate4LifeEntities1())
            {
                var favToRemove = context.UsersFavourites.Where(s=>s.UserId == userId && s.DonorId == donor.Id);

                foreach (var item in favToRemove)
                {
                    context.UsersFavourites.Remove(item);
                }

                context.SaveChanges();
                
            }

            return RedirectToAction("MyProfile", "Account");
        }


        [HttpGet]
        public ActionResult AddDonorToFavourites(Donor donor)
        {
            var userId = Convert.ToInt32(Session["UserId"]);

            using (var context = new Donate4LifeEntities1())
            {
                var user = context.Users.FirstOrDefault(s => s.Id == userId);

                if (user == null)
                {
                    return RedirectToAction("ListAllDonors", "Donor");
                }

                user.UsersFavourites.Add(new UsersFavourites { DonorId = donor.Id, UserId = userId });

                context.SaveChanges();
            }

            return RedirectToAction("ListAllDonors", "Donor");
        }
    }
}
