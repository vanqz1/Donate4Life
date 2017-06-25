using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donate4Life.Models
{
    public class CriteriaMenus
    {
        public List<string> listAge = new List<string>
            {
                "Всички",
                "18-25",
                "26-35",
                "36-49",
                ">50"
            };

        public List<string> listHeight = new List<string>
            {
                "Всички",
                "< 150 см",
                "150 - 170 см",
                "170 - 185 см",
                "> 185 см"
            };

        public List<string> listWeight = new List<string>
            {
                "Всички",
                "50 - 65 кг",
                "65 - 80 кг",
                "80 - 95 кг",
                "95 - 110 кг",
                "> 110 кг"
            };

        public List<string> listEyeColor = new List<string>
            {
                "зелени",
                "зелено-сиви",
                "кафяви",
                "кафяво-зелени",
                "кафяво-сиви",
                "сиви",
                "сини",
                "синьо-зелени",
                "синьо-сиви"
            };

        public List<string> listHairColor = new List<string>
            {
               "кафява",
               "руса",
               "тъмнокестенява",
               "червена",
               "черна"
            };

        public List<string> other = new List<string>
            {
                "Всички",
                "Най-нови",
                "Най-разглеждани",
                "Най-предпочитани"
            };
    }
}