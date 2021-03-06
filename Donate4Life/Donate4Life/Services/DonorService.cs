﻿using Donate4Life.Models;
using System;
using System.Linq;

namespace Donate4Life.Services
{
    public class DonorService
    {
        public void AddNewDonor(Donor donor)
        {
            using (var context = new Donate4LifeEntities1())
            {
                context.Donors.Add(new Donors {
                    Description = donor.Description,
                    EyeColor = donor.EyeColor,
                    HairColor = donor.HairColor,
                    Age = donor.Age,
                    Height = donor.Height,
                    Kilos = donor.Kilous,
                    Town = donor.Town,
                    Views = 0,
                    AddedDate = DateTime.Now
                });

                context.SaveChanges();             
            }
        }

        public bool CheckIfDonorIsInUserFav(int userId,int donorId)
        {
            using (var context = new Donate4LifeEntities1())
            {
                var isInUserFAv = context.UsersFavourites.Any(s => s.UserId == userId && s.DonorId == donorId);

                return isInUserFAv;
            }
        }
    }
}