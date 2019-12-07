using Microsoft.AspNetCore.Mvc;
using StudenUzMu.Interfaces;
using StudenUzMu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Controllers
{
    public class JurnalVaqtiController:Controller
    {
        private readonly IJurnalVaqtiRepository _jurnalVaqtiRepository;
        private readonly IFakultetRepository _fakultetRepository;
        private readonly IFanlarRepository _fanlarRepository;
        private readonly IUqituvchiRepository _uqituvchiRepository;
        private readonly IYonalishRepository _yonalishRepository;
        public JurnalVaqtiController(IJurnalVaqtiRepository jurnalVaqtiRepository,
            IFakultetRepository fakultetRepository,
            IFanlarRepository fanlarRepository,
            IUqituvchiRepository uqituvchiRepository,
            IYonalishRepository yonalishRepository)
        {
            _jurnalVaqtiRepository = jurnalVaqtiRepository;
            _fakultetRepository = fakultetRepository;
            _fanlarRepository = fanlarRepository;
            _uqituvchiRepository = uqituvchiRepository;
            _yonalishRepository = yonalishRepository;
        }

        public IActionResult Index(int? fanid,int? sem,int? fakid,int? kurs,int? gn,int? yonid) {
            ViewBag.Fan = _fanlarRepository.GetAll();
            ViewBag.Fak = _fakultetRepository.GetAll();
            ViewBag.Yon = _yonalishRepository.GetAll();
            var jurnalV = _jurnalVaqtiRepository.GetAllWithALL();
            if (fanid != null)
                jurnalV = jurnalV.Where(a => a.FanlarId == fanid);
            if(sem!=null)
                jurnalV = jurnalV.Where(a => a.Semister == sem);
            if(fakid!=null)
                jurnalV = jurnalV.Where(a => a.FakultetId == fakid);
            if(kurs!=null)
                jurnalV = jurnalV.Where(a => a.Kurs == kurs);
            if(gn!=null)
                jurnalV = jurnalV.Where(a => a.Guruh_nomer == gn);
            if(yonid!=null)
                jurnalV = jurnalV.Where(a => a.YonalishId == yonid);


            return View(jurnalV);
        }

        public IActionResult Create() {
            var jurnaJV = new JurnalVaqtiViewModel()
            {
                Fakultets = _fakultetRepository.GetAll(),
                Fanlars = _fanlarRepository.GetAll(),
                Uqituvchis = _uqituvchiRepository.GetAll(),
                Yonalishes = _yonalishRepository.GetAll()
            };
            return View(jurnaJV);
        }

        [HttpPost]
        public IActionResult Create(JurnalVaqtiViewModel jurnalVaqtiViewModel) {
            _jurnalVaqtiRepository.Create(jurnalVaqtiViewModel.JurnalVaqti);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) {
            var juranJV = new JurnalVaqtiViewModel()
            {
                JurnalVaqti = _jurnalVaqtiRepository.GetById(id),
                Fakultets = _fakultetRepository.GetAll(),
                Fanlars = _fanlarRepository.GetAll(),
                Uqituvchis = _uqituvchiRepository.GetAll(),
                Yonalishes = _yonalishRepository.GetAll()
            };
            return View(juranJV);
        }
        [HttpPost]
        public IActionResult Update(JurnalVaqtiViewModel jurnalVaqtiViewModel) {
            _jurnalVaqtiRepository.Update(jurnalVaqtiViewModel.JurnalVaqti);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) {
            var JV = _jurnalVaqtiRepository.GetById(id);
            _jurnalVaqtiRepository.Delete(JV);
            return RedirectToAction("Index");
        }
    }
}
