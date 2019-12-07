using Microsoft.AspNetCore.Mvc;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Controllers
{
    public class FanlarController:Controller
    {
        private readonly IFanlarRepository _fanlarRepository;
        public FanlarController(IFanlarRepository fanlarRepository)
        {
            _fanlarRepository = fanlarRepository;
        }

        public IActionResult Index() {
            var fan = _fanlarRepository.GetAll();
            return View(fan);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Fanlar fanlar) {
            _fanlarRepository.Create(fanlar);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id) {
            var fan = _fanlarRepository.GetById(id);
            return View(fan);
        }

        [HttpPost]
        public IActionResult Update(Fanlar fanlar) {
            _fanlarRepository.Update(fanlar);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) {
            var fan = _fanlarRepository.GetById(id);
            _fanlarRepository.Delete(fan);
            return RedirectToAction("Index");
        }
    }
}
