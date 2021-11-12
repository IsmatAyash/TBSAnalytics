using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.ViewModels
{
    public class CardStatView
    {
        public string CurAbv { get; set; }
        public string CustId { get; set; }
        public string CardType { get; set; }
        public int CardCount { get; set; }
        [Column(TypeName = "decimal(20,3)")]
        public decimal LbpBal { get; set; }
        [Column(TypeName = "decimal(20,3)")]
        public decimal UsdBal { get; set; }
    }
}
