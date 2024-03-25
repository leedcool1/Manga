using Manga.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manga.ViewModels
{
    public class TruyenViewModel
    {
        public int TruyenID { get; set; }
        public string Name { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public string AnhDaiDien { get; set; }
        public string Mota { get; set; }
        public List<Truyen> Truyens { get; set; } 
        public DateTime NgayDang { get; set; }
    }
}