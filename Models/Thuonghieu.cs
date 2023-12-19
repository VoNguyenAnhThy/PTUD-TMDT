using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S_me.Models
{
    public class Thuonghieu
    {
        [Key]
        public int ThuonghieuID { get; set; }
        [Display(Name = "Thương hiệu")]
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public virtual IList<Sanpham> Sanphams { get; set; }

    }
}