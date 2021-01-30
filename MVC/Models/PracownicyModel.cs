using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class PracownicyModel
    {
        public int IdPracownika { get; set; }
        public int IdFirmy { get; set; }
        [Required(ErrorMessage = "Wymagane pole")]
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NrTelefonu { get; set; }
        public string Email { get; set; }
    }
}