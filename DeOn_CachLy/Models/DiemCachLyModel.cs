using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DeOn_CachLy.Models
{
    public class DiemCachLyModel
    {
        [Key]
        [Display(Name ="Mã điểm cách ly")]
        [StringLength(4, ErrorMessage ="Mã điểm cách ly <= 4 kí tự")]
        public string MaDiemCachLy { get; set; }

        [Display(Name = "Tên điểm cách ly")]
        [StringLength(256, ErrorMessage = "Tên điểm cách ly <= 256 kí tự")]
        public string TenDiemCachLy { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(4, ErrorMessage = "Địa chỉ <= 256 kí tự")]
        public string DiaChi { get; set; }
    }
}
