using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PracownicyController : Controller
    {
        // GET: Pracownicy
        public ActionResult Index()
        {
            IEnumerable<PracownicyModel> PracownicyLista;
            HttpResponseMessage response = ZmienneGlobalne.WebApiClient.GetAsync("Pracownicy").Result;
            PracownicyLista = response.Content.ReadAsAsync<IEnumerable<PracownicyModel>>().Result;
            return View(PracownicyLista);
        }

        public ActionResult PracownicyFirmy(int id = 0)
        {
            if (id == 0)
            {
                return View(new PracownicyModel());
            }
            else
            {
                IEnumerable<PracownicyModel> PracownicyLista;
                HttpResponseMessage response = ZmienneGlobalne.WebApiClient.GetAsync("Narzedzia/GetPracownicyFirmy?id=" + id.ToString()).Result;
                PracownicyLista = response.Content.ReadAsAsync<IEnumerable<PracownicyModel>>().Result;
                return View(PracownicyLista);
            }
        }

        public ActionResult DodajLubEdytuj(int id = 0)
        {
            if (id == 0)
            {
                return View(new PracownicyModel());
            }
            else
            {
                HttpResponseMessage response = ZmienneGlobalne.WebApiClient.GetAsync("Pracownicy/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<PracownicyModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult DodajLubEdytuj(PracownicyModel pracownik)
        {
            if (pracownik.IdPracownika == 0)
            {
                HttpResponseMessage response = ZmienneGlobalne.WebApiClient.PostAsJsonAsync("Pracownicy", pracownik).Result;
                TempData["Sukces"] = "Pomyślnie zapisano";
            }
            else
            {
                HttpResponseMessage response = ZmienneGlobalne.WebApiClient.PutAsJsonAsync("Pracownicy/" + pracownik.IdPracownika, pracownik).Result;
                TempData["Sukces"] = "Pomyślnie edytowano";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Usun(int id)
        {
            HttpResponseMessage response = ZmienneGlobalne.WebApiClient.DeleteAsync("Pracownicy/" + id.ToString()).Result;
            TempData["Sukces"] = "Usunięto pracownika";
            return RedirectToAction("Index");
        }
    }
}