using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.Models
{
    public class CurRate
    {
        [Key]
        [Column(TypeName = "char(2)")]
        public string CurCode { get; set; }
        [Column(TypeName = "char(3)")]
        public string CurISOCode { get; set; }
        [Column(TypeName = "char(5)")]
        public string CurAbv { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CurName { get; set; }
        [Column(TypeName = "decimal(20,9)")]
        public decimal LBPRate { get; set; }
        [Column(TypeName = "decimal(20,9)")]
        public decimal USDRate { get; set; }
    }
}
