using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S_me.Models
{
    public class Form
    {
        [Key]
        public int formID { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Điền họ và tên")]
        [StringLength(200, MinimumLength = 3)]
        public string CustomerName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Điền email của bạn")]
        [StringLength(100, MinimumLength = 3)]
        public string CustomerEmail { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Điền số điện thoại của bạn")]
        [StringLength(12, MinimumLength = 10)]
        public string CustomerPhone { get; set; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Điền nội dung tin nhắn")]
        [StringLength(500, MinimumLength = 20)]
        public string CustomerMessage { get; set; }
    }
}