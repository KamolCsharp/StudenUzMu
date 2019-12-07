using Microsoft.AspNetCore.Mvc;
using StudenUzMu.Interfaces;
using StudenUzMu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Controllers
{
    public class YonalishController : Controller
    {
        private readonly IYonalishRepository _yonalishRepository;
        private readonly IFakultetRepository _fakultetRepository;
        public YonalishController(IYonalishRepository yonalishRepository,IFakultetRepository fakultetRepository)
        {
            _fakultetRepository = fakultetRepository;
            _yonalishRepository = yonalishRepository;
        }

        public IActionResult Index() {
            var yon = _yonalishRepository.GetAllWithFakultet();
            return View(yon);
        }

        public IActionResult Create() {
            var yonalish = new YonalishViewModel() {
                Fakultet = _fakultetRepository.GetAll()
            };
            return View(yonalish);
        }

        [HttpPost]
        public IActionResult Create(YonalishViewModel yonalishView) {
            _yonalishRepository.Create(yonalishView.Yonalish);
            return RedirectToAction("Index");

        }
        public IActionResult Update(int id) {
            var yonalish = new YonalishViewModel()
            {
                Yonalish = _yonalishRepository.GetById(id),
                Fakultet = _fakultetRepository.GetAll()
            };
            return View(yonalish);
        }

        [HttpPost]
        public IActionResult Update(YonalishViewModel yonalishView) {
            _yonalishRepository.Update(yonalishView.Yonalish);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var yon = _yonalishRepository.GetById(id);
            _yonalishRepository.Delete(yon);
            return RedirectToAction("Index");
        }
    }
}
