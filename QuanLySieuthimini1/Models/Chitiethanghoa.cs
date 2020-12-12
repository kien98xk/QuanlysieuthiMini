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
        [Display(Name = "Mã Hàng Hoá")]
        public int Ma_HH { get; set; }
        [Required]
        [Display(Name = "Tên Hàng Hoá")]
        public string Ten_HH { get; set; }
        [Required]
        [Display(Name = "Giá Mua")]
        public int GiaMua { get; set; }
        [Required]
        [Display(Name = "Giá Bán")]
        public int GiaBan { get; set; }
        [Required]
        [Display(Name = "Nơi Sản Xuất")]
        public string Noi_SX { get; set; }
        [Required]
        [Display(Name = "Hạn Sử Dụng")]
        public DateTime HSD { get; set; }
        [Required]
        [Display(Name = "Số Lượng Nhập")]
        public string SoLuongNhap { get; set; }
        [Required]
        [Display(Name = "Mã Nhóm Hàng")]
        public int Ma_NH { get; set; }
        public virtual ICollection<Hanghoa> Hanghoas { get; set; } 
        [ForeignKey("Ma_NH")]
        public virtual Nhomhang Nhomhangs { get; set; }
    }
}