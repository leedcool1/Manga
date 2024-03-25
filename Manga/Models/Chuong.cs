using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Manga.Models
{
    [Table("Chuong")]
    public class Chuong
    {
        [Key]
        public int ChuongID { get; set; }
        public string TenChuong { get; set; }
        public string ChuongSo{ get; set; }
        public DateTime NgayUp { get; set; }
        public virtual Truyen Truyen { get; set; }
        public int TruyenID { get; set; }
        public virtual ICollection<Chuong_HinhAnh> Chuong_HinhAnhs { get; set; }
    }
}