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
        [Display(Name = "Mã nhân viên")]
        public int Ma_NV { get; set; }
        [Required, MaxLength(30)]
        [Display(Name = "Tên nhân viên")]
        public string Ten_NV { get; set; }
        [Required]
        [Display(Name = "Số điện thoại")]
        public int SĐT { get; set; }
        [Required]
        [Display(Name = "Địa chỉ")]
        public string Diachi { get; set; }
        [Required]
        [Display(Name = "Giới tính")]
        public string Gioitinh { get; set; }
        [Display(Name = "Ngày vào làm")]
        public string Ngayvaolam { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
        [Required, EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Chức vụ")]
        public string Role { get; set; }
        [Required]
        [Display(Name = "Mật khẩu")]
        public string Matkhau { get; set; }
        [NotMapped]
        [Required]
        [Compare("Matkhau")]
        public string Xacnhanmatkhau { get; set; }

    }
}