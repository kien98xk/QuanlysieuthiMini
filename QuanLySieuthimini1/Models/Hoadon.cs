using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class Hoadon
    {
        [Key]
        public int Ma_HD { get; set; }
        public int Ma_HH { get; set; }
        public string Ten_HH { get; set; }
        public int Ma_NV { get; set; }
        public int TongTien { get; set; }
        public string Trangthai { get; set; }
        public DateTime Ngaytaohoadon { get; set; }
        [ForeignKey("Ma_NV")]
        public Nhanvien Nhanvien { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        [ForeignKey("Ma_HH")]
        public Hanghoa Hanghoa { get; set; }
    }
}