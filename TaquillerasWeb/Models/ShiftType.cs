using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Models
{
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
