using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S_me.Models
{
    public class Chitietdonhang
    {
        [Key]
        public int ChitietID { get; set; }

        [ForeignKey("DHObj")]
        public int DHID { get; set; }
        public virtual Donhang DHObj { get; set; }

        [ForeignKey("SanphamObj")]
        public int SpID { get; set; }
        public virtual Sanpham SanphamObj { get; set; }

        public int Soluong { get; set; }
        public decimal Dongia { get; set; }

    }
}