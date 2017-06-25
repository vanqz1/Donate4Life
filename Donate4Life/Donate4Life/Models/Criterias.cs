using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Donate4Life.Models
{
    [Serializable()]
    public class Criterias
    { 
        public string Age { get; set; }
        public string Height { get; set; }
        public string Kilous { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string OtherCriteria { get; set; }
    }
}