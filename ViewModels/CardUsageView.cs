using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.ViewModels
{
    public class CardUsageView
    {
        public string CustId { get; set; }
        public string CardType { get; set; }
        public string TrxType { get; set; }
        public int CardCount { get; set; }
        [Column(TypeName = "decimal(20,3)")]
        public decimal UsdBal { get; set; }
    }
}
