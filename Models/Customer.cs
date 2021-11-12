using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBSAnalytics.Models
{
    public enum CustType
    {
        Corporate,
        Establishment
    }

    public class Customer
    {
        [Key]
        [Column(TypeName = "nvarchar(16)")]
        public string CustId { get; set; }
        [Column(TypeName = "nvarchar(225)")]

        public string CustName { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public CustType CustType { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string CustStatus { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime EnrolledDate { get; set; }
        public bool Enrolled { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string MarketSegment { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string ServicePackage { get; set; }
        [Column(TypeName = "nvarchar(5)")]

        public string BrcCode { get; set; }
        [ForeignKey("BrcCode")]

        public virtual Branch Branch { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public string EcoSectId { get; set; }
        [ForeignKey("EcoSectId"), Column(Order = 0)]
        public virtual EcoSector EcoSectors { get; set; }
        [Column(TypeName = "nvarchar(5)")]

        #nullable enable
        [ForeignKey("EnrolledDate")]
        public virtual DimDate? EnrolledDates { get; set; }
        [ForeignKey("OpenDate")]
        public virtual DimDate? OpenDates { get; set; }
        #nullable disable
    }
}
