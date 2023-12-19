using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Web;

namespace S_me.Models
{
    public class Khachhang
    {
        //public Khachhang()
        //{
        //    //this.Donhangs = new HashSet<Donhang>();
        //    Donhangs = new List<Donhang>();
        //}
        [Key]
        public int KHID { get; set; }
        [Display(Name = "Tên KH")]
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dc { get; set; }
        public string Sdt { get; set; }
        public virtual IList<Donhang> Donhangs { get; set; }

        //[ForeignKey("DHObj")]
        //public int DHID { get; set; }
        //public virtual Donhang DHObj { get; set; }
        //public virtual ICollection<Donhang> Donhangs { get; set; }
        //public IList<Donhang> Donhangs { get; set; }


    }
}