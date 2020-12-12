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
        [Display(Name = "Mã Nhân Viên")]
        public int Ma_NV { get; set; }
        [Required, MaxLength(30)]
        [Display(Name = "Tên Nhân Viên")]
        public string Ten_NV { get; set; }
        [Required]
        [Display(Name = "Số ĐT")]
        public int SĐT { get; set; }
        [Required]
        [Display(Name = "Địa Chỉ")]
        public string Diachi { get; set; }
        [Required]
        [Display(Name = "Giới Tính")]
        public string Gioitinh { get; set; }
        [Required]
        [Display(Name = "Ngày Vào Làm")]
        public string Ngayvaolam { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
        [Required, EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Role")]
        public string Role { get; set; }
        [Required]
        [Display(Name = "Mật Khẩu")]
        public string Matkhau { get; set; }
        [NotMapped]
        [Required]
        [Compare("Matkhau")]
        [Display(Name = "Xác Nhận Mật Khẩu")]
        public string Xacnhanmatkhau { get; set; }

    }
}