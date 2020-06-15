using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
namespace Taquilleras.Entities
{
    [Table("TicketOffice")]
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
        [Computed]
        public virtual ICollection<DepositSlip> DepositSlip { get; set; }
        [Computed]
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
