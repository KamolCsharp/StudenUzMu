using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using StudenUzMu.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Controllers
{
    public class JurnalController : Controller
    {
        public string SessionId { get; set; }
        public string SessionFam { get; set; }
        public string SessionIsm { get; set; }
        public string SessionSharf { get; set; }
        public string SessionRasm { get; set; }
        private readonly IJurnalRepository _jurnalRepository;
        private readonly IUqituvFanRepository _uqituvFanRepository;
        private readonly IUqituvchiRepository _uqituvchiRepository;
        private readonly IUquvchiRepository _uquvchiRepository;
        private readonly IFakultetRepository _fakultetRepository;
        private readonly DataContext _context;
        private readonly IFanlarRepository _fanlarRepository;
        private readonly IJurnalVaqtiRepository _jurnalVaqtiRepository;
        private readonly IYonalishRepository _yonalishRepository;
        public JurnalController(DataContext context,
            IUqituvFanRepository uqituvFanRepository,
            IJurnalRepository jurnalRepository,
            IUqituvchiRepository uqituvchiRepository,
            IUquvchiRepository uquvchiRepository,
            IFakultetRepository fakultetRepository,
            IJurnalVaqtiRepository jurnalVaqtiRepository,
            IFanlarRepository fanlarRepository,
            IYonalishRepository yonalishRepository)
        {
            _jurnalRepository = jurnalRepository;
            _context = context;
            _uqituvFanRepository = uqituvFanRepository;
            _uqituvchiRepository = uqituvchiRepository;
            _uquvchiRepository = uquvchiRepository;
            _fakultetRepository = fakultetRepository;
            _fanlarRepository = fanlarRepository;
            _yonalishRepository = yonalishRepository;
            _jurnalVaqtiRepository = jurnalVaqtiRepository;

        }

        [HttpGet]
        public IActionResult Search(int? page, string fam,string ism,
            string sharf,int? sem,int? fanid,int? baxo,int? g_num,int? kurs,
            int? fakid,int? yonid) {
            var jurnal = _jurnalRepository.GetAllWithALL().ToList();
            if (fam != null)
                jurnal = jurnal.Where(a => a.Uquvchi.Familiyasi.Contains(fam)).ToList();
            if(ism!=null)
                jurnal = jurnal.Where(a => a.Uquvchi.Ismi.Contains(ism)).ToList();
            if(sharf!=null)
                jurnal = jurnal.Where(a => a.Uquvchi.Sharifi.Contains(sharf)).ToList();
            if (sem != null)
                jurnal = jurnal.Where(a => a.Semister == sem).ToList();
            if(fanid!=null)
                jurnal = jurnal.Where(a => a.FanlarId == fanid).ToList();
            if(baxo!=null)
                jurnal = jurnal.Where(a => a.Baxo == baxo).ToList();
            if(g_num!=null)
                jurnal = jurnal.Where(a => a.Guruh_nomeri == g_num).ToList();
            if(kurs!=null)
                jurnal = jurnal.Where(a => a.Kursi == kurs).ToList();
            if(fakid!=null)
                jurnal = jurnal.Where(a => a.Uquvchi.FakultetId == fakid).ToList();
            if(yonid!=null)
                jurnal = jurnal.Where(a => a.Uquvchi.YonalishId == yonid).ToList();

            ViewBag.Fak = _fakultetRepository.GetAll();
            ViewBag.Yon = _yonalishRepository.GetAll();
            ViewBag.Fan = _fanlarRepository.GetAll();
            return View("index",jurnal);
        }
        public IActionResult Index(int? page) {
            ViewBag.Fak = _fakultetRepository.GetAll();
            ViewBag.Yon = _yonalishRepository.GetAll();
            ViewBag.Fan = _fanlarRepository.GetAll();
            var jurnal = _jurnalRepository.GetAllWithALL().ToPagedList(page ?? 1, 15);
            ViewBag.count = jurnal.TotalItemCount;
            return View(jurnal);
        }

        public IActionResult UquvJurnal(int? Id, string fam, string ism, string sharf, string rasm) {
            ViewBag.Fam = fam;
            ViewBag.Ism = ism;
            ViewBag.Sharf = sharf;
            ViewBag.Rasm = rasm;
            var jurnal = _jurnalRepository.GetAllWithALL().Where(j => j.UquvchiId == Id).ToList();
            return View(jurnal);
        }
        [HttpGet]
        public IActionResult UqituvchiJurnal(int Id, string fam, string ism, string sharf, string rasm)
        {
            var dd = _jurnalRepository.GetAll().Where(m => m.UqituvchiId == Id);
            //Uqituvchi fanlari nomi va Idni olish olish
            //var tt = _uqituvFanRepository.GetAllWith().Where(a => a.UqituvchiId == Id)
            //    .Select(a => a?.Fanlar.Nomi+a?.FanlarId);

            HttpContext.Session.SetInt32("SessionId", Id);
            HttpContext.Session.SetString("SessionFam", fam);
            HttpContext.Session.SetString("SessionIsm", ism);
            HttpContext.Session.SetString("SessionSharf", sharf);
            HttpContext.Session.SetString("SessionRasm", rasm);
            ViewBag.Id = Id;
            ViewBag.Fam = fam;
            ViewBag.Ism = ism;
            ViewBag.Rasm = rasm;
            ViewBag.Sharf = sharf;
            
            FanlarTop(Id);
            var jurnal = _jurnalRepository.GetAllWithALL().Where(j => j.UqituvchiId == Id).ToList();
            return View(jurnal);
        }

        private void FanlarTop(int Id)
        {
            List<UqituvFan> uqituvs = _uqituvFanRepository.GetAllWith().Where(a => a.UqituvchiId == Id).ToList();
            List<Fanlar> fanlars = new List<Fanlar>(uqituvs.Count());
            for (int i = 0; i < uqituvs.Count(); i++)
            {
                fanlars.Add(uqituvs[i].Fanlar);
            }
            ViewBag.Fan = fanlars;
            ViewBag.JurnalVaqti = _jurnalVaqtiRepository.GetAllWithALL().Where(j => j.UqituvchiId == Id).ToList();
            ViewBag.Fak = _fakultetRepository.GetAll();
            ViewBag.Yon = _yonalishRepository.GetAll();
        }

        [HttpGet]
        public IActionResult SelectUq(string famu, string ismu, string sharfu, int? sem, int? fanid, int? gn, int? kurs, int? fakid, int? yonid) {

            var Id = HttpContext.Session.GetInt32("SessionId");
            var fam = HttpContext.Session.GetString("SessionFam");
            var ism = HttpContext.Session.GetString("SessionIsm");
            var sharf = HttpContext.Session.GetString("SessionSharf");
            var rasm = HttpContext.Session.GetString("SessionRasm");
            ViewBag.Id = Id;
            ViewBag.Fam = fam;
            ViewBag.Ism = ism;
            ViewBag.Rasm = rasm;
            ViewBag.Sharf = sharf;
            ViewBag.JurnalVaqti = _jurnalVaqtiRepository.GetAllWithALL().Where(j => j.UqituvchiId == Id).ToList();
            var jurnal = _jurnalRepository.GetAllWithALL().Where(j => j.UqituvchiId == Id).ToList();
            if (famu != null)
                jurnal = jurnal.Where(j => j.Uquvchi.Familiyasi.Contains(famu)).ToList();
            if (ismu != null)
                jurnal = jurnal.Where(j => j.Uquvchi.Ismi.Contains(ismu)).ToList();
            if (sharfu != null)
                jurnal = jurnal.Where(j => j.Uquvchi.Sharifi.Contains(sharfu)).ToList();
            if (sem != null)
                jurnal = jurnal.Where(j => j.Semister == sem).ToList();
            if (fanid != null)
                jurnal = jurnal.Where(j => j.FanlarId == fanid).ToList();
            if (gn != null)
                jurnal = jurnal.Where(j => j.Guruh_nomeri == gn).ToList();
            if (kurs != null)
                jurnal = jurnal.Where(j => j.Kursi == kurs).ToList();
            if (fakid != null)
                jurnal = jurnal.Where(j => j.Uquvchi.FakultetId == fakid).ToList();
            if (yonid != null)
                jurnal = jurnal.Where(j => j.Uquvchi.YonalishId == yonid).ToList();
            FanlarTop(Convert.ToInt32(Id));

            return View("UqituvchiJurnal", jurnal);
        }

        [HttpGet]
        public IActionResult InsertUquvchi(int? jId, string joriy, string or1, string or2, string yak, string jam, string reti, string baxo, string sana) {
            var Id = HttpContext.Session.GetInt32("SessionId");
            var fam = HttpContext.Session.GetString("SessionFam");
            var ism = HttpContext.Session.GetString("SessionIsm");
            var sharf = HttpContext.Session.GetString("SessionSharf");
            var rasm = HttpContext.Session.GetString("SessionRasm");

            if (jId != null)
            {
                Jurnal _jurnal = _context.Jurnal.Single(j => j.Id == jId);
                if (joriy != null)
                    _jurnal.Joriy = Convert.ToInt32(joriy);
                if (or1 != null)
                    _jurnal.Oraliq_1 = Convert.ToInt32(or1);
                if (or2 != null)
                    _jurnal.Oraliq_2 = Convert.ToInt32(or2);
                if (yak != null)
                    _jurnal.Yakuniy = Convert.ToInt32(yak);
                if (jam != null)
                    _jurnal.Jami = Convert.ToInt32(jam);
                if (reti != null)
                    _jurnal.Reting = Convert.ToInt32(reti);
                if (baxo != null)
                    _jurnal.Baxo = Convert.ToInt32(baxo);
                if (sana != null)
                    _jurnal.Sana = Convert.ToDateTime(sana);

                _jurnalRepository.Update(_jurnal);

            }
            ViewBag.Id = Id;
            ViewBag.Fam = fam;
            ViewBag.Ism = ism;
            ViewBag.Rasm = rasm;
            ViewBag.Sharf = sharf;
            var jurnal = _jurnalRepository.GetAllWithALL().Where(j => j.UqituvchiId == Id).ToList();
            FanlarTop(Convert.ToInt32(Id));
            return View("UqituvchiJurnal", jurnal);
        }

        [HttpGet]
        public IActionResult UpdateAll(int gn,int sem,int kurs,int fanid) {
            ViewBag.Save = false;
            var jurnal = _jurnalRepository.GetAllWithALL()
                .Where(a => a.Guruh_nomeri == gn)
                .Where(a => a.Semister == sem)
                .Where(a => a.Kursi == kurs)
                .Where(a => a.FanlarId == fanid)
                .ToList();
            return View(jurnal);
        }

        [HttpPost]
        public IActionResult UpdateAll(int?[] id,int?[] joriy,int?[] oraliq1,
            int?[] oraliq2,int?[] yakuniy,int?[] jami,int?[] reting,int?[] baxo,DateTime?[] sana) {

            Jurnal jurnal = null;
            if (joriy.Count() > 0)
            {
                for (int i = 0; i < joriy.Count(); i++)
                {
                    if (joriy[i] != null) { 
                        jurnal = _context.Jurnal.Single(a => a.Id == id[i]);
                        jurnal.Joriy = Convert.ToInt32(joriy[i]);
                        jurnal.Jami += Convert.ToInt32(joriy[i]);
                        _jurnalRepository.Update(jurnal);
                         } 
               }
                ViewBag.Save = true;
            }

            if (oraliq1.Count() > 0)
            {
                for (int i = 0; i < oraliq1.Count(); i++)
                {
                    if (oraliq1 != null)
                    {
                        jurnal = _context.Jurnal.Single(a => a.Id == id[i]);
                        jurnal.Oraliq_1 = Convert.ToInt32(oraliq1[i]);
                        jurnal.Jami += Convert.ToInt32(oraliq1[i]);
                        _jurnalRepository.Update(jurnal);
                    }
                }
                ViewBag.Save = true;

            }
            if (oraliq2.Count() > 0)
            {
                for (int i = 0; i < oraliq2.Count(); i++)
                {
                    if (oraliq2[i] != null)
                    {
                        jurnal = _context.Jurnal.Single(a => a.Id == id[i]);
                        jurnal.Oraliq_2 = Convert.ToInt32(oraliq2[i]);
                        jurnal.Jami += Convert.ToInt32(oraliq2[i]);

                        _jurnalRepository.Update(jurnal);
                    }
                }
                ViewBag.Save = true;

            }
            if (yakuniy.Count() > 0)
            {
                for (int i = 0; i < yakuniy.Count(); i++)
                {
                    if (yakuniy[i] != null)
                    {
                        jurnal = _context.Jurnal.Single(a => a.Id == id[i]);
                        jurnal.Yakuniy = Convert.ToInt32(yakuniy[i]);
                        jurnal.Jami += Convert.ToInt32(yakuniy[i]);

                        _jurnalRepository.Update(jurnal);
                    }
                }
                ViewBag.Save = true;
            }
          
            if (reting.Count() > 0)
            {
                for (int i = 0; i < reting.Count(); i++)
                {
                    if (reting[i] != null)
                    {
                        jurnal = _context.Jurnal.Single(a => a.Id == id[i]);
                        jurnal.Reting = Convert.ToInt32(reting[i]);
                        _jurnalRepository.Update(jurnal);
                    }
                }
                ViewBag.Save = true;
            }
            if (baxo.Count() > 0)
            {
                for (int i = 0; i < baxo.Count(); i++)
                {
                    if (baxo[i] != null)
                    {
                        jurnal = _context.Jurnal.Single(a => a.Id == id[i]);
                        jurnal.Baxo = Convert.ToInt32(baxo[i]);
                        _jurnalRepository.Update(jurnal);
                    }
                }
                ViewBag.Save = true;
            }
            if (sana.Count() > 0)
            {
                for (int i = 0; i < sana.Count(); i++)
                {
                    if (sana[i] != null)
                    {
                        jurnal = _context.Jurnal.Single(a => a.Id == id[i]);
                        jurnal.Sana = Convert.ToDateTime(sana[i]);
                        _jurnalRepository.Update(jurnal);
                    }
                }
                ViewBag.Save = true;
            }

            return View("Thanks");
        }
        public IActionResult Update(int id) {
            var jurnal = new JurnalViewModel()
            {
                Jurnal = _jurnalRepository.GetById(id),
                Fanlars = _fanlarRepository.GetAll(),
                Uqituvchis = _uqituvchiRepository.GetAll(),
                Uquvchis = _uquvchiRepository.GetAll(),
                Fakultets = _fakultetRepository.GetAll(),
                Yonalishes = _yonalishRepository.GetAll()
            };
            return View(jurnal);
        }

        [HttpPost]
        public IActionResult Update(JurnalViewModel jurnalView) {
            _jurnalRepository.Update(jurnalView.Jurnal);
            return RedirectToAction("Index");
        }
        public IActionResult Create() {
            var jurnal = new JurnalViewModel() {
                Fanlars = _fanlarRepository.GetAll(),
                Uqituvchis = _uqituvchiRepository.GetAll(),
                Uquvchis = _uquvchiRepository.GetAll(),
                Yonalishes=_yonalishRepository.GetAll(),
                Fakultets=_fakultetRepository.GetAll()
            };
            return View(jurnal);
        }

        [HttpPost]
        public IActionResult Create(JurnalViewModel jurnalView) {
            _jurnalRepository.Create(jurnalView.Jurnal);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id) {
            var jurnal = _jurnalRepository.GetById(id);
            _jurnalRepository.Delete(jurnal);
            return RedirectToAction("Index");
        }
    }
}
