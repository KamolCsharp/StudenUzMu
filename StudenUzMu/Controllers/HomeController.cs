using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;

namespace StudenUzMu.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUquvchiRepository _uquvchiRepository;
        private readonly IUqituvchiRepository _uqituvchiRepository;
        public HomeController(IUqituvchiRepository uqituvchiRepository,IUquvchiRepository uquvchiRepository)
        {
            _uqituvchiRepository = uqituvchiRepository;
            _uquvchiRepository = uquvchiRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Error = false;
            return View();
        }
        [HttpPost]
        public IActionResult LoginIndex(string login, string parol)
        {
            var list = _uquvchiRepository.GetAll().Where(m => m.Pasport.Equals(login))
                .Where(m => m.Parol.Equals(parol)).ToList();
            if (list.Count() > 0)
            {
                int id = list[0].UquvchiId;

                string rasm = list[0].Rasmi;
                return RedirectPermanent("~/Jurnal/UquvJurnal?Id=" + id + "&fam=" + list[0].Familiyasi + "&ism=" + list[0].Ismi + "&sharf=" + list[0].Sharifi + "&rasm=" + rasm);
            }
            List<Uqituvchi> listuqituvchi = _uqituvchiRepository.GetAll().Where(m => m.Pasport.Equals(login)).Where(m => m.Parol.Equals(parol)).ToList();
            if (listuqituvchi.Count() > 0)
            {
                int id = listuqituvchi[0].Id;
                string rasm = listuqituvchi[0].Rasm;
                return RedirectPermanent("~/Jurnal/UqituvchiJurnal?Id=" + id + "&fam=" + listuqituvchi[0].Familiyasi + "&ism=" + listuqituvchi[0].Ismi + "&sharf=" + listuqituvchi[0].Sharifi + "&rasm=" + rasm);
            }
            else
            {
                ViewBag.Error = true;
                return View("Index", "Home");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
