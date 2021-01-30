using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class FirmyModel
    {
        public int IdFirmy { get; set; }
        public int IdSiedzibyFirmy { get; set; }

        [Required(ErrorMessage= "Wymagane pole")]
        public string NazwaFirmy { get; set; }
        public string Nip { get; set; }
        public string Regon { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NrBudynku { get; set; }
        public string NrLokalu { get; set; }
        public string KodPocztowy { get; set; }
        public string Poczta { get; set; }
        public string NrTelefonu { get; set; }
        public string Kraj { get; set; }
        public string Email { get; set; }
        public string StronaWWW { get; set; }
        public string NrKonta { get; set; }
    }
}