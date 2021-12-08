using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeOn_CachLy.Models
{
    public class CongNhanModel
    {
        [Key]
        [Display(Name = "Mã công nhân")]
        [StringLength(4, ErrorMessage = "Mã công nhân <= 4 kí tự")]
        public string MaCongNhan { get; set; }

        [Display(Name = "Tên công nhân")]
        [StringLength(256, ErrorMessage = "Tên công nhân <= 256 kí tự")]
        public string TenCongNhan { get; set; }

        [Display(Name = "Giới tính")]      
        public bool GioiTinh { get; set; }

        [Display(Name = "Năm sinh")]       
        public int Namsinh { get; set; }

        [Display(Name = "Nước về")]
        [StringLength(256, ErrorMessage = "Nước về <= 256 kí tự")]
        public string NuocVe { get; set; }

        [Display(Name = "Mã điểm cách ly")]
        [ForeignKey("MaDiemCachLy")]
        [StringLength(4, ErrorMessage = "Mã điểm cách ly <= 4 kí tự")]        
        public string MaDiemCachLy { get; set; }


    }
}
