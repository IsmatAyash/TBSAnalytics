using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBSAnalytics.Models
{
    public class TrxType
    {
        [Key]
        [Column(TypeName = "tinyint")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TrxTypeId { get; set; }
        [Column(TypeName = "nvarchar(60)")]

        public string TrxTypeDesc { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
