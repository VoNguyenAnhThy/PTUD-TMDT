using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace S_me.Models
{
    public class Donhang
    {
        public Donhang() 
        {
            //this.Chitietdonhangs = new HashSet<Chitietdonhang>();
            Chitietdonhangs = new List<Chitietdonhang>();

        }
        [Key]
        public int DHID { get; set; }
        public IList<Chitietdonhang> Chitietdonhangs { get; set; }
        public double TongTien { get; set; }
        public DateTime NgayLap { get; set; }

        //public virtual ICollection<Chitietdonhang> Chitietdonhangs { get; set; }
        [ForeignKey("KHObj")]
        public int KHID { get; set; }
        public virtual Khachhang KHObj { get; set; }
    }
}
