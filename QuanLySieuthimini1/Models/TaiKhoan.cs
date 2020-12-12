using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class TaiKhoan
    {
        [Key,Required]
        [Display(Name = "Mã Nhân Viên")]
        public int Ma_NV { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mật Khẩu")]
        public string Matkhau { get; set; }
        public Nhanvien Nhanvien { get; set; }
    }
}