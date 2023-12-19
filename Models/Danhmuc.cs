using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S_me.Models
{
    public class Danhmuc
    {
            [Key]
            public int DMID { get; set; }
            [Display(Name = "Danh mục")]
            [Required]
            [StringLength(200)]
            public string Name { get; set; }
            public virtual IList<Sanpham> Sanphams { get; set; }
        }
    }