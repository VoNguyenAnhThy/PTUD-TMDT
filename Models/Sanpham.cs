using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S_me.Models
{
    public class Sanpham
    {
        [Key]
        public int SpID { get; set; }

        [Display(Name = "Tên Sản phẩm")]
        [Required(ErrorMessage = "Điền tên sản phẩm")]
        [StringLength(200, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Display(Name = "Giá")]
        [Range(5000, double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:0,000}")]
        public decimal Price { get; set; }

        [Display(Name = "Mô tả")]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Summary { get; set; }

        public byte[] Picture { get; set; }
        [NotMapped]
        [Display(Name = "Hình ảnh")]
        public HttpPostedFileBase PictureUpload { get; set; }


        public byte[] Picture2 { get; set; }
        [NotMapped]
        [Display(Name = "Hình ảnh 2")]
        public HttpPostedFileBase PictureUpload2 { get; set; }

        [Display(Name = "Đánh giá")]
        [Range(1, 5)]
        public double Rated { get; set; }

        [Display(Name = "Tồn kho")]
        [Range(0, int.MaxValue)]
        public int Storage { get; set; }

        [ForeignKey("DanhmucObj")]
        public int? CatID { get; set; }
        public virtual Danhmuc DanhmucObj { get; set; }

        [ForeignKey("ThuonghieuObj")]
        public int? BrandID { get; set; }
        public virtual Thuonghieu ThuonghieuObj { get; set; }

        public IList<Chitietdonhang> Chitietdonhangs { get; set; }
        public virtual ICollection<Sanpham> Sanphamlienquans { get; set; }


    }
}