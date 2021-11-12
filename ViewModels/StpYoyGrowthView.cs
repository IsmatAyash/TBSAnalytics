using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.ViewModels
{
    public class StpYoyGrowthView
    {
        public int StpYear { get; set; }
        public string CustId { get; set; }
        public string CustType { get; set; }
        public string StpType { get; set; }
        public int StpCount { get; set; }
        [Column(TypeName = "decimal(38,3)")]
        public decimal StpAmount { get; set; }
    }
}
