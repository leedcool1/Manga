using Manga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Manga.ViewModels;
using System.IO;

namespace Manga.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index(string SearchString)
        {
            var trs = context.Truyens.Select(x => x);
            if (!String.IsNullOrEmpty(SearchString))
            {
                SearchString = SearchString.ToLower();
                trs = trs.Where(b => b.Name.ToLower().Contains(SearchString));
            }

            var truyenList = trs.ToList();

            if (truyenList.Count == 0)
            {
                // Hiển thị thông báo không tìm thấy truyện
                TempData["Message"] = "Không tìm thấy truyện.";
            }

            return View(truyenList);
        }
        public ActionResult Info(int id) 
        {
            
            Truyen tr = context.Truyens.Where(x => x.TruyenID == id).FirstOrDefault();
            ViewBag.Chuong = context.Chuongs.ToList();
            return View(tr);
        }
        public ActionResult ChuongAnh(int id)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            Chuong_HinhAnh ch = context.Chuong_HinhAnhs.Where(x => x.Chuong.ChuongID == id).FirstOrDefault();
            ViewBag.Img = context.Chuong_HinhAnhs.ToList();
            ViewBag.DS = context.Chuongs.ToList();
            return View(ch);
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new TruyenViewModel
            {

            };
            return View();
        }
        [HttpPost]
        public ActionResult Create(TruyenViewModel viewModel, HttpPostedFileBase image)
        {
            if (image != null)
            {
                string ImageName = Path.GetFileName(image.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Images/AnhDaiDien"), ImageName);
                image.SaveAs(path);
                var truyen = new Truyen()
                {
                    Name = viewModel.Name,
                    TheLoai = viewModel.TheLoai,
                    TacGia = viewModel.TacGia,
                    AnhDaiDien = image.FileName,
                    Mota = viewModel.Mota,
                    NgayDang = DateTime.Now
            };
                context.Truyens.Add(truyen);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
        [Authorize]
        public ActionResult AddChapter()
        {
            var viewModel = new ChuongHinhAnhModel
            {
               truyen = context.Truyens.ToList(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddChapter( ChuongHinhAnhModel viewModel, HttpPostedFileBase[] images)
        {
            Chuong chuong = new Chuong();
            if (ModelState.IsValid)
            {
                List<Chuong_HinhAnh> imgs = new List<Chuong_HinhAnh>();
                for (int i = 0; i < images.Count(); i++)
                {
                    var item = images[i];
                    if (item != null )
                    {
                        string ImageName = Path.GetFileName(item.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/Images/HinhAnhChapter"), ImageName);
                        item.SaveAs(path);
                        Chuong_HinhAnh image1 = new Chuong_HinhAnh()
                        {
                            url = item.FileName,
                            ChuongID = viewModel.ChuongID,
                        };
                        chuong.TenChuong = viewModel.TenChuong;
                        chuong.ChuongSo= viewModel.ChuongSo;
                        chuong.NgayUp = DateTime.Now;
                        chuong.TruyenID = viewModel.TruyenID;
                        imgs.Add(image1);
                    }
                }
                chuong.Chuong_HinhAnhs = imgs;
                context.Chuongs.Add(chuong);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        [Authorize]
        public ActionResult EditChapter(int id)
        { 
            var chuong = context.Chuongs.Single(c => c.ChuongID == id);
            ViewBag.Chuong = context.Truyens.ToList();
            return View(chuong);
        }
        [HttpPost]
        public ActionResult EditChapter( Chuong chuong, HttpPostedFileBase[] images)
        {
            if (ModelState.IsValid)
            {
                for (int i = 0; i < images.Count(); i++)
                {
                    var image = images[i];
                    if (image != null )
                    {
                        var img = Path.GetFileName(image.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Images/HinhAnhChapter"), img);
                        image.SaveAs(path);
                        var image1 = new Chuong_HinhAnh()
                        {
                            url = image.FileName,
                            ChuongID = chuong.ChuongID,
                        };
                        context.Chuong_HinhAnhs.Add(image1);
                    }
                }
                context.Entry(chuong).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuong);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var truyen = context.Truyens.Single(c => c.TruyenID == id);
            return View(truyen);
        }
        [HttpPost]
        public ActionResult Edit(Truyen truyen, HttpPostedFileBase image)
        {
            if (image != null)
            {
                string ImageName = Path.GetFileName(image.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Images/AnhDaiDien"), ImageName);
                image.SaveAs(path);
                truyen.Name = truyen.Name;
                truyen.TheLoai = truyen.TheLoai;
                truyen.TacGia = truyen.TacGia;
                truyen.AnhDaiDien = image.FileName;
                truyen.Mota = truyen.Mota;
                truyen.NgayDang = DateTime.Now;
                context.Entry(truyen).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(truyen);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            var truyen = context.Truyens.Single(c => c.TruyenID == id);
            context.Truyens.Remove(truyen);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        public ActionResult TimTheLoai(string a)
        {
            var trs = context.Truyens.Select(x => x);
            if (!String.IsNullOrEmpty(a))
            {
                a = a.ToLower();
                trs = trs.Where(b => b.TheLoai.ToLower().Contains(a));
            }
            return View(trs.ToList());
        }
    }
}