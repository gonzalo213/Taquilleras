using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
namespace Taquilleras.Entities
{
    [Table("ActionType")]
    public partial class ActionType
    {
        public ActionType()
        {
            TransactionDetail = new HashSet<TransactionDetail>();
        }
        [Key]
        public int IdTipoMovimiento { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}
