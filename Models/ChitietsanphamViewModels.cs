using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace S_me.Models
{
    public class ChitietsanphamViewModel
    {
        public Sanpham Sanphamchinh { get; set; }
        public List<Sanpham> Sanphamlienquans { get; set; }
    }
}