using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donate4Life.Services
{
    public class SearchByCriteriaService
    {
        private  IList<Donors> m_donors;

        public SearchByCriteriaService(IList<Donors> donors)
        {
            m_donors = donors;
        }

        public SearchByCriteriaService SearchByAge(string age)
        {
            var trimmedAge = age.Trim().ToLower();

            switch (trimmedAge)
            {
                case "всичко":
                    return this;
                case "18-25":
                    m_donors = m_donors.Where(s=>s.Age >= 18 && s.Age <=25).ToList();
                    return this;
                case "26-35":
                    m_donors = m_donors.Where(s => s.Age >= 26 && s.Age <= 35).ToList();
                    return this;
                case "36-49":
                    m_donors = m_donors.Where(s => s.Age >= 36 && s.Age <= 49).ToList();
                    return this;
                case ">50":
                    m_donors = m_donors.Where(s => s.Age >= 50).ToList();
                    return this;
                default:
                    return this;
            } 
        }

        public SearchByCriteriaService SearchByHeight(string height)
        {
            var trimmedAge = height.Trim().ToLower();

            switch (trimmedAge)
            {
                case "всичко":
                    return this;
                case "<150см":
                    m_donors = m_donors.Where(s => s.Height < 150).ToList();
                    return this;
                case "150-170см":
                    m_donors = m_donors.Where(s => s.Height <= 170 && s.Age >= 150).ToList();
                    return this;
                case "170-185см":
                    m_donors = m_donors.Where(s => s.Age >= 170 && s.Age <= 185).ToList();
                    return this;
                case ">185см":
                    m_donors = m_donors.Where(s => s.Age >= 185).ToList();
                    return this;
                default:
                    return this;
            }
        }

        public SearchByCriteriaService SearchByWeight(string weight)
        {
            var trimmedAge = weight.Trim().ToLower();

            switch (trimmedAge)
            {
                case "всичко":
                    return this;
                case "50-65кг":
                    m_donors = m_donors.Where(s => s.Height >= 50 && s.Height <=65).ToList();
                    return this;
                case "65-80кг":
                    m_donors = m_donors.Where(s => s.Height >= 65 && s.Age <= 80).ToList();
                    return this;
                case "95-110кг":
                    m_donors = m_donors.Where(s => s.Height >= 95 && s.Height <= 110).ToList();
                    return this;
                case ">110кг":
                    m_donors = m_donors.Where(s => s.Height >= 110).ToList();
                    return this;
                default:
                    return this;
            }
        }

        public SearchByCriteriaService SearchByEyeColor(string eyeColor)
        {
            var trimmedAge = eyeColor.Trim().ToLower();

            m_donors = m_donors.Where(s => s.EyeColor == eyeColor).ToList();
            return this;
        }

        public SearchByCriteriaService SearchByHairColor(string hairColor)
        {
            var trimmedAge = hairColor.Trim().ToLower();

            m_donors = m_donors.Where(s => s.HairColor == hairColor).ToList();
            return this;
        }

        public IList<Donors> GetFilteredDonors()
        {
            return m_donors;
        }
    }
}