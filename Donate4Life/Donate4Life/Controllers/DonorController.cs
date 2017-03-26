using Donate4Life.Models;
using Donate4Life.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Donate4Life.Controllers
{
    public class DonorController : Controller
    {
        public ActionResult AddNewDonor(Donor donor)
        {
            if (ModelState.IsValid)
            {
            }

            donor = new Donor()
            {
                AddedDay = DateTime.Now,
                Age = 23,
                Description = "dsf",
                EyeColor = "Blue",
                HairColor = "Blond",
                Height = 167,
                Kilous = 30,
                Town = "Sofia",
                Views = 0
            };

            var donorService = new DonorService();
            donorService.AddNewDonor(donor);

            return View(donor);
        }
    }
}