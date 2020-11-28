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
        public int Ma_NCC { get; set; }
        [Required]
        public string Ten_NCC { get; set; }
        [Required]
        public string Diachi { get; set; }
        [Required]
        public int SĐT { get; set; }
        [Required]
        public string Email { get; set; }
        public virtual ICollection<Hanghoa> Hanghoas { get; set; }
    }
}