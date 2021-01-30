using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace API.Controllers
{
    public class NarzedziaController : ApiController
    {
        private readonly KontrahenciEntities db = new KontrahenciEntities();

        public IQueryable<Pracownicy> GetPracownicyFirmy(int id)
        {
            IQueryable<Pracownicy> pracownicy = db.Pracownicy.Where(prac => prac.IdFirmy == id);
            return pracownicy;
        }
    }
}
