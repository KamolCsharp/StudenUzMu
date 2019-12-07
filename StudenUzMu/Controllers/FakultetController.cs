using Microsoft.AspNetCore.Mvc;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Controllers
{
    public class FakultetController : Controller
    {
        private readonly IFakultetRepository _fakultetRepository;
        public FakultetController(IFakultetRepository fakultetRepository)
        {
            _fakultetRepository = fakultetRepository;
        }

        public IActionResult Index() {
            var fak = _fakultetRepository.GetAll();
            return View(fak);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fakultet fakultet) {
            _fakultetRepository.Create(fakultet);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var fak = _fakultetRepository.GetById(id);
            _fakultetRepository.Delete(fak);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) {
            var fak = _fakultetRepository.GetById(id);
            return View(fak);
        }

        [HttpPost]
        public IActionResult Update(Fakultet fakultet) {
            _fakultetRepository.Update(fakultet);
            return RedirectToAction("Index");
        }
    }
}
