using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            TransactionDetail = new HashSet<TransactionDetail>();
        }

        public int Id { get; set; }
        public int KeyTaq { get; set; }
        public int ShiftTypeId { get; set; }
        public DateTime DateVenta { get; set; }
        public string Status { get; set; }
        public string Inter { get; set; }
        public string InterSap { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual TicketOffice KeyTaqNavigation { get; set; }
        public virtual ShiftType ShiftType { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}
