using System;
using System.ComponentModel.DataAnnotations;

namespace Donate4Life.Models
{
    public class Donor
    {
        [Required(ErrorMessage ="sdfsdfsfsdf")]
        public string Description { get; set; }

        public string HairColor { get; set; }

        public string EyeColor { get; set; }

        public int Age { get; set; }

        public int Kilous { get; set; }

        public int Height { get; set; }

        public string Town { get; set; }

        public DateTime AddedDay { get; set; }

        public int Views { get; set; }
    }
}