using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taquilleras.Entities
{
    [Dapper.Contrib.Extensions.Table("DepositSlip")]
    public partial class DepositSlip
    {
        public int Id { get; set; }
        public int TicketOfficeId { get; set; }
        public int ShiftTypeId { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime DateSale { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime DateDeposit { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public decimal Import { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string NumFicha { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string NumEnvase { get; set; }
        public string Expediente { get; set; }
        public string Status { get; set; }
        public string Inter { get; set; }
        public string InterSap { get; set; }

        //public virtual ShiftType ShiftType { get; set; }
        //public virtual TicketOffice TicketOffice { get; set; }
    }
}
