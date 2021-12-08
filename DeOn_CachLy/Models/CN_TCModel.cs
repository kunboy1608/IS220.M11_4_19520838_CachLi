using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeOn_CachLy.Models
{
    public class CN_TCModel
    {
        [Display(Name = "Mã công nhân")]
        [ForeignKey("MaCongNhan")]
        [StringLength(4, ErrorMessage = "Mã công nhân <= 4 kí tự")]
        public string MaCongNhan { get; set; }

        [Display(Name = "Mã triệu chứng")]
        [ForeignKey("MaTrieuChung")]
        [StringLength(4, ErrorMessage = "Mã triệu chứng <= 4 kí tự")]
        public string MaTrieuChung { get; set; }


    }
}
