using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class Nhacungcap
    {
        [Key, Required]
        [Display(Name = "Mã Nhà Cung Cấp")]
        public int Ma_NCC { get; set; }
        [Required]
        [Display(Name = "Tên Nhà Cung Cấp")]
        public string Ten_NCC { get; set; }
        [Required]
        [Display(Name = "Địa Chỉ")]
        public string Diachi { get; set; }
        [Required]
        [Display(Name = "Số ĐT")]
        public int SĐT { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public virtual ICollection<Hanghoa> Hanghoas { get; set; }
    }
}