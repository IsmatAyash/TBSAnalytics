using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.Models
{
    public class CardUsage
    {
        [Key]
        public int Id { get; set; }
        public int CardYear { get; set; }
        public int CardMonth { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string CardType { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string TrxType { get; set; }
        public int TrxCount { get; set; }
        public decimal TrxAmountUsd { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string CustId { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer Customers { get; set; }
    }
}
