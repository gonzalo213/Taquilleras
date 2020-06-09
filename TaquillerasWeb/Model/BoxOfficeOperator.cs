using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Model
{
    public partial class BoxOfficeOperator
    {
        public int UserId { get; set; }
        public int TicketOfficeId { get; set; }
        public int ShiftTypeId { get; set; }
        public string Expedient { get; set; }

        public virtual ShiftType ShiftType { get; set; }
        public virtual TicketOffice TicketOffice { get; set; }
        public virtual User User { get; set; }
    }
}
