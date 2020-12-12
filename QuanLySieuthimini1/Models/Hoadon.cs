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
        [Display(Name = "Mã Hoá Đơn")]
        public int Ma_HD { get; set; }
        [Required]
        [Display(Name = "Mã Hàng Hoá")]
        public int Ma_HH { get; set; }
        [Required]
        [Display(Name = "Tên Hàng Hoá")]
        public string Ten_HH { get; set; }
        [Required]
        [Display(Name = "Mã Nhân Viên")]
        public int Ma_NV { get; set; }
        [Required]
        [Display(Name = "Tổng Tiền")]
        public int TongTien { get; set; }
        [Required]
        [Display(Name = "Trạng Thái")]
        public string Trangthai { get; set; }
        [Required]
        [Display(Name = "Ngày Tạo Hoá Đơn")]
        public DateTime Ngaytaohoadon { get; set; }
        [ForeignKey("Ma_NV")]
        public Nhanvien Nhanvien { get; set; }
        public virtual ICollection<Chitiethoadon> Chitiethoadons { get; set; }
        [ForeignKey("Ma_HH")]
        public Hanghoa Hanghoa { get; set; }
    }
}