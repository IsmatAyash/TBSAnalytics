using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.Models
{
    public class FFMonthlyBalance
    {
        [Key]
        public int Id { get; set; }
        [DataType("decimal(38,3)")]
        public decimal Balance { get; set; }
        [DataType("decimal(38,9)")]
        public decimal BalanceUsd { get; set; }
        public string CustType { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
