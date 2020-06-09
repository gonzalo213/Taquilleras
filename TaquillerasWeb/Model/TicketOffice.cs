using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Model
{
    public partial class TicketOffice
    {
        public TicketOffice()
        {
            DepositSlip = new HashSet<DepositSlip>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string NumPos { get; set; }
        public string PhoneExt { get; set; }
        public string Status { get; set; }
        public string ActiveTaq { get; set; }
        public string PosAux1 { get; set; }
        public string PosAux2 { get; set; }
        public string PosAux3 { get; set; }

        public virtual ICollection<DepositSlip> DepositSlip { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
