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
        public int Ma_HH { get; set; }
        [Required]
        public int Ma_NCC { get; set; }
        [Required]
        public int Ma_NH { get; set; }
        [Required]
        public string Ten_HH { get; set; }
        public Chitiethanghoa Chitiethanghoa { get; set; }
        [ForeignKey("Ma_NH")]
        public virtual Nhomhang Nhomhang { get; set; }
        [ForeignKey("Ma_NCC")]
        public virtual Nhacungcap Nhacungcap { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
    }
}