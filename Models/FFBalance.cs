using System.ComponentModel.DataAnnotations;

namespace TBSAnalytics.Models
{
    public class FFBalance
    {
        [Key]
        public int Id { get; set; }
        public string CustId { get; set; }
        public string CustType { get; set; }
        public string BalCurrency { get; set; }
        [DataType("decimal(38,3)")]
        public decimal Balance { get; set; }
        [DataType("decimal(38,9)")]
        public decimal BalanceUsd { get; set; }

    }
}
