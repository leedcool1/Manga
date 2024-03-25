using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Manga.Models
{
    [Table("Truyen")]
    public class Truyen
    {
        [Key]
        public int TruyenID { get; set; }
        public string Name { get; set; }
        public string TheLoai { get; set; }
        public string TacGia { get; set; }
        public string AnhDaiDien { get; set; }
        public string Mota { get; set; }
        public DateTime NgayDang { get; set; }
        public virtual ICollection<Chuong> Chuongs { get; set; }
    }
}