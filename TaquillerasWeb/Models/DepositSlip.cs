using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Models
{
    public partial class DepositSlip
    {
        public int Id { get; set; }
        public int TicketOfficeId { get; set; }
        public int ShiftTypeId { get; set; }
        public DateTime DateSale { get; set; }
        public DateTime DateDeposit { get; set; }
        public decimal Import { get; set; }
        public string NumFicha { get; set; }
        public string NumEnvase { get; set; }
        public string Expediente { get; set; }
        public string Status { get; set; }
        public string Inter { get; set; }
        public string InterSap { get; set; }

        public virtual ShiftType ShiftType { get; set; }
        public virtual TicketOffice TicketOffice { get; set; }
    }
}
