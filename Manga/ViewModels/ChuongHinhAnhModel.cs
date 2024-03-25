using Manga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manga.ViewModels
{
    public class ChuongHinhAnhModel
    {
        public int ChuongID { get; set; }
        public string TenChuong { get; set; }
        public string ChuongSo { get; set; }
        public DateTime NgayUp { get; set; }
        public IEnumerable<Truyen> truyen { get; set; }
        public int TruyenID { get; set; }

    }
}