using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.ViewModels
{
    public class StpView
    {
        public int StpYear { get; set; }
        public int StpMonth { get; set; }
        public string CustId { get; set; }
        public string CustName { get; set; }
        public string CustType { get; set; }
        public string StpType { get; set; }
        public string Channel { get; set; }
        public string Memo { get; set; }
        public int StpCount { get; set; }
        [Column(TypeName = "decimal(38,3)")]
        public decimal StpAmount { get; set; }
    }
}
