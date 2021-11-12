using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBSAnalytics.Models
{
    public class EcoSector
    {
        [Key]
        [Column(TypeName = "nvarchar(5)")]
        public string EcoSectId { get; set; }
        [Column(TypeName = "nvarchar(225)")]

        public string EcoSectDesc { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
