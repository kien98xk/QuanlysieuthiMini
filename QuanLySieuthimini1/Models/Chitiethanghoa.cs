using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class Chitiethanghoa
    {
        [Key,Required]
        public int Ma_HH { get; set; }
        [Required]
        public int GiamMua { get; set; }
        [Required]
        public int GiaBan { get; set; }
        [Required]
        public string Noi_SX { get; set; }
        [Required]
        public DateTime HSD { get; set; }
        [Required]
        public string Loai_HH { get; set; }
        [Required]
        public string SoLuongNhap { get; set; }
        [Required]
        public int Ma_NH { get; set; }
        public virtual ICollection<Hanghoa> Hanghoas { get; set; } 
    }
}