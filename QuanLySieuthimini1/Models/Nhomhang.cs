using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class Nhomhang
    {
        [Key, Required]
        [Display(Name = "Mã Nhóm Hàng")]
        public int Ma_NH { get; set; }
        [Required]
        [Display(Name = "Tên Nhóm Hàng")]
        public string Ten_NH { get; set; }
        public virtual ICollection<Hanghoa> Hanghoas { get; set; }
        public virtual ICollection<Chitiethanghoa> Chitiethanghoas { get; set; }

    }
}