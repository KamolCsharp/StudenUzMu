using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using StudenUzMu.Interfaces;
using StudenUzMu.Models;
using System;
using System.Collections.Generic;
using System.IO;
using PagedList;
using System.Linq;
using System.Threading.Tasks;

namespace StudenUzMu.Controllers
{
    public class UqituvchiController : Controller
    {
        private readonly IFileProvider _fileProvider;
        private readonly IHostingEnvironment _hostingEnvironment;
        public readonly IUqituvchiRepository _uqituvchiRepository;
        public UqituvchiController(IUqituvchiRepository uqituvchiRepository,
            IFileProvider fileProvider, IHostingEnvironment hostingEnvironment)
        {
            _uqituvchiRepository = uqituvchiRepository;
            _fileProvider = fileProvider;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index(int? page) {
            var uqituvchi = _uqituvchiRepository.GetAll().ToPagedList(page ?? 1, 12);
            ViewBag.count = uqituvchi.TotalItemCount;
            return View(uqituvchi);
        }
        [HttpGet]
        public IActionResult SelectUq(int? page, string fam, string ism) {
            var uqituvchi = _uqituvchiRepository.GetAll();
            if (fam != null)
                uqituvchi = uqituvchi.Where(m => m.Familiyasi.Contains(fam));
            if(ism!=null)
                uqituvchi = uqituvchi.Where(m => m.Ismi.Contains(ism));
            uqituvchi = uqituvchi.ToPagedList(page ?? 1, 12);
            ViewBag.count = uqituvchi.Count();
            return View("Index",uqituvchi);
        }
        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Uqituvchi uqituvchi, IFormFile file) {
            if (ModelState.IsValid)
            {
                _uqituvchiRepository.Create(uqituvchi);
                                 
                if (file != null || file.Length != 0)
                {
                    FileInfo fi = new FileInfo(file.FileName);

                    var newFilename = uqituvchi.Rasm + "_" + String.Format("{0:d}",
                                      (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = _hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\Rasm\UqituvchiRasm\" + newFilename);
                    var pathToSave = @"/Rasm/UqituvchiRasm/" + newFilename;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                         file.CopyTo(stream);
                    }

                    uqituvchi.Rasm = pathToSave;
                    _uqituvchiRepository.Update(uqituvchi);
                }
                return RedirectToAction("Index");

            }
            return View(uqituvchi);
        }
        public IActionResult About(int id) {
            var uqituvchi = _uqituvchiRepository.GetAll().Single(m=>m.Id==id);
            return View(uqituvchi);
        }
        public IActionResult Update(int id) {
            var uqituvchi = _uqituvchiRepository.GetById(id);
            _uqituvchiRepository.Update(uqituvchi);
            return View(uqituvchi);
        }

        [HttpPost]
        public IActionResult Update(Uqituvchi uqituvchi, IFormFile file) {
            if (ModelState.IsValid)
            {
                _uqituvchiRepository.Update(uqituvchi);
                if(file==null||file.Length==0)
                    return RedirectToAction("Index");

               else if (file != null || file.Length != 0)
                {
                    FileInfo fi = new FileInfo(file.FileName);

                    var newFilename = uqituvchi.Rasm + "_" + String.Format("{0:d}",
                                      (DateTime.Now.Ticks / 10) % 100000000) + fi.Extension;
                    var webPath = _hostingEnvironment.WebRootPath;
                    var path = Path.Combine("", webPath + @"\Rasm\UqituvchiRasm\" + newFilename);
                    var pathToSave = @"/Rasm/UqituvchiRasm/" + newFilename;

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    uqituvchi.Rasm = pathToSave;
                    _uqituvchiRepository.Update(uqituvchi);
                }
                return RedirectToAction("Index");
            }
            return View(uqituvchi);
        }

        public IActionResult Delete(int id) {
            var uq = _uqituvchiRepository.GetById(id);
            _uqituvchiRepository.Delete(uq);
            return RedirectToAction("Index");
        }
    }
}
