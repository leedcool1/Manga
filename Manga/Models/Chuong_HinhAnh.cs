using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Manga.Models
{
    [Table("Chuong_HinhAnh")]
    public class Chuong_HinhAnh
    {
        [Key]
        public int AnhID { get; set; }
        public string TenAnh { get; set; }
        public string url { get; set; }
        public int? ChuongID { get; set; }
        public virtual Chuong Chuong { get; set; }
    }
}