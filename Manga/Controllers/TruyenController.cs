using Manga.Models;
using Manga.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Manga.Controllers
{
    public class TruyenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly object _hostEnvironment;

        // GET: Default
        public TruyenController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpGet]
        public ActionResult AddChapter()
        {
            ViewBag.TruyenList = new SelectList(_context.Truyens.ToList(), "TruyenID", "TenTruyen");
            return View();
        }

/*[HttpPost]
[ValidateAntiForgeryToken]
public async Task<ActionResult> AddChapter(Chuong chuong, IEnumerable<IFormFile> files)
{

    if (ModelState.IsValid)
    {
        chuong.NgayUp = DateTime.Now;
        _context.Chuongs.Add(chuong);
        await _context.SaveChangesAsync();

        if (files != null && files.Count() > 0)
        {
            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(_hostEnvironment.WebRootPath, "uploads", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    var chuonhinh = new Chuong_HinhAnh
                    {
                        TenAnh = fileName,
                        url = filePath,
                        ChuongID = chuong.ChuongID
                    };
                    _context.Chuong_HinhAnhs.Add(chuonhinh);
                }
            }
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
    ViewBag.TruyenList = new SelectList(_context.Truyens.ToList(), "TruyenID", "TenTruyen", chuong.TruyenID);
    return View(chuong);
}*/

    }
}