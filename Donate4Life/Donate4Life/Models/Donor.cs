using Donate4Life.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Donate4Life.Models
{
    public class Donor
    {
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

        [Required(ErrorMessage = "Задължително поле.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Задължително поле.")]
        public string HairColor { get; set; }

        [Required(ErrorMessage = "Задължително поле.")]
        public string EyeColor { get; set; }

        [Required(ErrorMessage = "Задължително поле.")]
        [PosNumberNoZero(ErrorMessage = "Стойността трябва да е по-голяма от 0")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Задължително поле.")]
        [PosNumberNoZero(ErrorMessage = "Стойността трябва да е по-голяма от 0")]
        public int Kilous { get; set; }

        [Required(ErrorMessage = "Задължително поле.")]
        [PosNumberNoZero(ErrorMessage = "Стойността трябва да е по-голяма от 0")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Задължително поле.")]
        public string Town { get; set; }

        public DateTime AddedDay { get; set; }

        public int Views { get; set; }

        public int Id { get; set; }
    }
}