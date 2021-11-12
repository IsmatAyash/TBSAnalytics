using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.Models
{
    public class DimDate
    {
        [Key]
        public DateTime DateKey { get; set; }
        public int DayNumberOfWeek { get; set; }
        [Column(TypeName="nvarchar(30)")]
        public string DayNameOfWeek { get; set; }
        public int DayNumberOfMonth { get; set; }
        public int DayNumberOfYear { get; set; }
        public int WeekNumberOfYear { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string EnglishMonthName { get; set; }
        public int MonthNumberOfYear { get; set; }
        public int CalendarQuarter { get; set; }
        public int CalendarYear { get; set; }
        public int CalendarSemester { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }





    }
}
