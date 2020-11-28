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
        public int Ma_NV { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Matkhau { get; set; }
        public Nhanvien Nhanvien { get; set; }
    }
}