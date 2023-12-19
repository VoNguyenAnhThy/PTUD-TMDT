using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S_me.Models
{
    public class Admin
    {
        [Key]
        public string UserAdmin { get; set; }
        public string PassAdmin { get; set; }
        public string Hoten { get; set; }
    }
}