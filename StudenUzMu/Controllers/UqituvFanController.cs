using Microsoft.AspNetCore.Mvc;
using StudenUzMu.Interfaces;
using StudenUzMu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Controllers
{
    public class UqituvFanController:Controller
    {
        private readonly IUqituvFanRepository _uqituvFanRepository;
        private readonly IFanlarRepository _fanlarRepository;
        private readonly IUqituvchiRepository _uqituvchiRepository;
        public UqituvFanController(IUqituvFanRepository uqituvFanRepository,
            IUqituvchiRepository uqituvchiRepository,IFanlarRepository fanlarRepository)
        {
            _uqituvFanRepository = uqituvFanRepository;
            _uqituvchiRepository = uqituvchiRepository;
            _fanlarRepository = fanlarRepository;
        }

        public IActionResult Index() {
            var uq = _uqituvFanRepository.GetAllWith();
            return View(uq);
        }

        public IActionResult Create() {
            var uq = new UqituvFanViewModel()
            {
                Fanlars = _fanlarRepository.GetAll(),
                Uqituvchis = _uqituvchiRepository.GetAll()
            };
            return View(uq);
        }

        [HttpPost]
        public IActionResult Create( UqituvFanViewModel uqituvFanViewModel) {
            _uqituvFanRepository.Create(uqituvFanViewModel.UqituvFan);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) {
            var uq = new UqituvFanViewModel()
            {
                UqituvFan = _uqituvFanRepository.GetById(id),
                Fanlars = _fanlarRepository.GetAll(),
                Uqituvchis = _uqituvchiRepository.GetAll()
            };
            return View(uq);
        }

        [HttpPost]
        public IActionResult Update(UqituvFanViewModel uqituvFanViewModel) {
            _uqituvFanRepository.Update(uqituvFanViewModel.UqituvFan);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var uq = _uqituvFanRepository.GetById(id);
            _uqituvFanRepository.Delete(uq);
            return RedirectToAction("Index");
        }
        
    }
}
