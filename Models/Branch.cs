using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TBSAnalytics.Models
{
    public class Branch
    {
        [Key]
        [Column(TypeName = "nvarchar(5)")]

        public string BrcCode { get; set; }
        [Column(TypeName = "nvarchar(225)")]

        public string BrcName { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string BrcRegion { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string BrcStatus { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string RMName { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
