using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBSAnalytics.Models
{
    public class Transaction
    {
        [Key]
        public int TrxId { get; set; }
        public DateTime TrxDate { get; set; }
        [Column(TypeName = "char(16)")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TrxChannel { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public string TrxCurrency { get; set; }
        [Column(TypeName = "decimal(20,3)")]
        public decimal TrxAmount { get; set; }
        [Column(TypeName = "decimal(20,3)")]
        public decimal TrxAmountUsd { get; set; }
        public string Narration1 { get; set; }
        public string Narration2 { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string TrxRef { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string TrxSubType { get; set; }
        public int TrxSubTypeCount { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string CustId { get; set; }
        [ForeignKey("CustId")]
        public virtual Customer Customers { get; set; }
        [Column(TypeName = "tinyint")]
        public int TrxTypeId { get; set; }
        [ForeignKey("TrxTypeId")]
        public virtual TrxType TrxTypes { get; set; }
        [ForeignKey("TrxDate")]
        public virtual DimDate TrxDates { get; set; }
    }
}
