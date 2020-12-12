using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class Hanghoa
    {
        [Key]
        [Display(Name = "Mã Hàng Hoá")]
        public int Ma_HH { get; set; }
        [Required]
        [Display(Name = "Mã Nhà Cung Cấp")]
        public int Ma_NCC { get; set; }
        [Required]
        [Display(Name = "Mã Nhóm Hàng")]
        public int Ma_NH { get; set; }
        [Required]
        [Display(Name = "Tên Hàng Hoá")]
        public string Ten_HH { get; set; }
        public Chitiethanghoa Chitiethanghoa { get; set; }
        [ForeignKey("Ma_NH")]
        public virtual Nhomhang Nhomhang { get; set; }
        [ForeignKey("Ma_NCC")]
        public virtual Nhacungcap Nhacungcap { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}