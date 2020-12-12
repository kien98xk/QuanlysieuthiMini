using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class Chitiethoadon
    {
        [Key, Required]
        [Display(Name = "Mã Chi Tiết Hoá Đơn")]
        public int Ma_CTHD { get; set; }
        [Required]
        [Display(Name = "Mã Hoá Đơn")]
        public int Ma_HD { get; set; }
        [Required]
        [Display(Name = "Tên Hàng Hoá")]
        public string Ten_HH { get; set; }
        [Required]
        [Display(Name = "Số Lượng")]
        public int Soluong { get; set; }
        [Required]
        [Display(Name = "Giá")]
        public int Gia { get; set; }
        [ForeignKey("Ma_HD")]
        public Hoadon Hoadon { get; set; }
    }
}