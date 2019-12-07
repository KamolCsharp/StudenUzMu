using Microsoft.AspNetCore.Mvc;
using StudenUzMu.Interfaces;
using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Threading.Tasks;
using PagedList;
using StudenUzMu.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using StudenUzMu.ViewModel;

namespace StudenUzMu.Controllers
{
    public class UquvchiController:Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFakultetRepository _fakultetRepository;
        private readonly IUquvchiRepository _uquvchiRepository;
        private readonly IYonalishRepository _yonalishRepository;
        private readonly IUqituvchiRepository _uqituvchiRepository;

        public UquvchiController(
            IUquvchiRepository uquvchiRepository,
            IFakultetRepository fakultetRepository,
            IUqituvchiRepository uqituvchiRepository,
            IYonalishRepository yonalishRepository,
            IFileProvider fileProvider,IHostingEnvironment hostingEnvironment)
        {
            _uquvchiRepository = uquvchiRepository;
            _fakultetRepository = fakultetRepository;
            _fileProvider = fileProvider;
            _yonalishRepository = yonalishRepository;
            _hostingEnvironment = hostingEnvironment;
            _uqituvchiRepository = uqituvchiRepository;
        }

        public IActionResult Index(int? page) {
            var uquvchi = _uquvchiRepository.GetAllWithFakultet().ToPagedList(page?? 1,15);
            ViewBag.count = uquvchi.TotalItemCount;
            return View(uquvchi);
        }

        [HttpGet]
        public IActionResult SelectUq(int? page,string fam,string ism,string sharf,string pasport,string manizl,
            string email,string tel_r,DateTime? sana) {
            var uquvchi = _uquvchiRepository.GetAllWithFakultet();
            if (fam != null)
                uquvchi = uquvchi.Where(m => m.Familiyasi.Contains(fam));
            if (ism != null)
                uquvchi = uquvchi.Where(m => m.Ismi.Contains(ism));
            if(sharf!=null)
                uquvchi = uquvchi.Where(m => m.Sharifi.Contains(sharf));
            if(pasport!=null)
                uquvchi = uquvchi.Where(m => m.Pasport.Contains(pasport));
            if(manizl!=null)
                uquvchi = uquvchi.Where(m => m.Manzil.Contains(manizl));
            if(email!=null)
                uquvchi = uquvchi.Where(m => m.Email.Contains(email));
            if (tel_r != null) 
                uquvchi = uquvchi.Where(m => m.Tel_raqami.Contains(tel_r));
            if(sana!=null)
                uquvchi = uquvchi.Where(m => m.Tugulgan_sana.Equals(sana));
            uquvchi = uquvchi.ToPagedList(page ?? 1, 15);
            ViewBag.count = uquvchi.Count();
            return View("Index",uquvchi);
        }



        public IActionResult Create() {
            var yonalish = new UquvchiViewModel()
            {
                Fakultet = _fakultetRepository.GetAll(),
                Yonalish =_yonalishRepository.GetAll()
                
            };
            return View(yonalish);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UquvchiViewModel uquvchiViewModel, IFormFile file) {
            if (ModelState.IsValid) {
            _uquvchiRepository.Create(uquvchiViewModel.Uquvchi);
                if (file != null || file.Length != 0)
                {
                    FileInfo fi = new FileInfo(file.FileName);

                    var newFilename = uquvchiViewModel.Uquvchi.Rasmi + "_" + String.Format("{0:d}",
                                      (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = _hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\Rasm\UquvchiRasm\" + newFilename);
                    var pathToSave = @"/Rasm/UquvchiRasm/" + newFilename;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    uquvchiViewModel.Uquvchi.Rasmi = pathToSave;
                    _uquvchiRepository.Update(uquvchiViewModel.Uquvchi);
                }
                return RedirectToAction("Index");
            }
            return View(uquvchiViewModel.Uquvchi);
        }

        public IActionResult Update(int id) {
            var uquvchi = new UquvchiViewModel()
            {
                Uquvchi = _uquvchiRepository.GetById(id),
                Fakultet = _fakultetRepository.GetAll(),
                Yonalish = _yonalishRepository.GetAll()
            };
            return View(uquvchi);
        }
        [HttpPost]
        public IActionResult Update(UquvchiViewModel uquvchiViewModel, IFormFile file) {
            if (ModelState.IsValid) {
            _uquvchiRepository.Update(uquvchiViewModel.Uquvchi);
                if (file == null || file.Length == 0)
                      return RedirectToAction("Index");
                else if (file != null || file.Length != 0)
                {
                    FileInfo fi = new FileInfo(file.FileName);

                    var newFilename = uquvchiViewModel.Uquvchi.Rasmi + "_" + String.Format("{0:d}",
                                      (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = _hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\Rasm\UquvchiRasm\" + newFilename);
                    var pathToSave = @"/Rasm/UquvchiRasm/" + newFilename;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    uquvchiViewModel.Uquvchi.Rasmi = pathToSave;
                    _uquvchiRepository.Update(uquvchiViewModel.Uquvchi);
                }
                return RedirectToAction("Index");
            }
            return View(uquvchiViewModel);
        }

        public IActionResult Delete(int id) {
            var uquvchi = _uquvchiRepository.GetById(id);
            _uquvchiRepository.Delete(uquvchi);
            return RedirectToAction("Index");
        }
    }
}
