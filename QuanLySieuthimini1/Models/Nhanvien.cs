using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class Nhanvien
    {
        [Key]
        public int Ma_NV { get; set; }
        [Required, MaxLength(30)]
        public string Ten_NV { get; set; }
        [Required]
        public int SĐT { get; set; }
        [Required]
        public string Diachi { get; set; }
        [Required]
        public string Gioitinh { get; set; }
        public string Ngayvaolam { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public string Role { get; set; }
        [Required]
        public string Matkhau { get; set; }
        [NotMapped]
        [Required]
        [Compare("Matkhau")]
        public string Xacnhanmatkhau { get; set; }

    }
}