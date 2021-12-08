using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DeOn_CachLy.Models
{
    public class TrieuChungModel
    {
        [Key]
        [Display(Name = "Mã triệu chứng")]
        [StringLength(4, ErrorMessage = "Mã triệu chứng <= 4 kí tự")]
        public string MaTrieuChung { get; set; }

        [Display(Name = "Tên triệu chứng")]
        [StringLength(256, ErrorMessage = "Tên triệu chứng <= 256 kí tự")]
        public string TenTrieuChung { get; set; }
    }
}
