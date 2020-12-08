using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLySieuthimini1.Models
{
    public class Chitiethoadon
    {
        [Key, Required]
        public int Ma_CTHD { get; set; }
        [Required]
        public int Ma_HD { get; set; }
        [Required]
        public int Ten_HH { get; set; }
        [Required]
        public int Soluong { get; set; }
        [Required]
        public int Gia { get; set; }
        [ForeignKey("Ma_HD")]
        public Hoadon Hoadon { get; set; }
    }
}