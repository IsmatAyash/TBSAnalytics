using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.Models
{
    public class CardStat
    {
        [Key]
        public int Id { get; set; }
        public int CardYear { get; set; }
        public int CardMonth { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string CardType { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public string CurAbv { get; set; }
        public int NumberOfCards { get; set; }
        [Column(TypeName = "decimal(20,3)")]
        public decimal OutstandingBal { get; set; }
        [Column(TypeName = "decimal(20,3)")]
        public decimal OutstandingBalUsd { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string CustId { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer Customers { get; set; }

    }
}
