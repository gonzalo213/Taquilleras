using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Dapper.Contrib.Extensions;
namespace Taquilleras.Entities
{
    [Table("ShiftType")]
    public partial class ShiftType
    {
        public ShiftType()
        {
            DepositSlip = new HashSet<DepositSlip>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DepositSlip> DepositSlip { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
