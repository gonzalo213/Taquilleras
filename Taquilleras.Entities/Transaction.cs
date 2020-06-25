using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
namespace Taquilleras.Entities
{
    [Table("SaleTransaction")]
    public partial class Transaction
    {
        
        public Transaction()
        {
            TransactionDetail = new List<TransactionDetail>();
            TicketOffice = new TicketOffice();
            ShiftType = new ShiftType();
            BoxOfficeOperator = new BoxOfficeOperator();
        }
        public Transaction(Transaction transaction)
        {
            this.Id = transaction.Id;
            this.DateVenta = transaction.DateVenta;
            this.TicketOfficeId = transaction.TicketOfficeId;
            this.BoxOfficeOperatorId = transaction.BoxOfficeOperatorId;
            this.ShiftTypeId = transaction.ShiftTypeId;
            this.Inter = transaction.Inter;
            this.InterSap = transaction.InterSap;
            this.Status = transaction.Status;
            this.TicketOffice = transaction.TicketOffice;
            this.ShiftType = transaction.ShiftType;
            this.BoxOfficeOperator = transaction.BoxOfficeOperator;
            this.TransactionDetail = new List<TransactionDetail>();
         }

        [Key]
        public int Id { get; set; }
        public int TicketOfficeId { get; set; }
        public int BoxOfficeOperatorId { get; set; }
        public int ShiftTypeId { get; set; }
        public DateTime? DateVenta { get; set; }
        public string Status { get; set; }
        public string Inter { get; set; }
        public string InterSap { get; set; }
        public decimal? TotalAmount { get; set; }
        [Computed]
        public virtual List<TransactionDetail> TransactionDetail { get; set; }
        [Computed]
        public virtual ShiftType ShiftType { get; set; }
        [Computed]
        public virtual BoxOfficeOperator BoxOfficeOperator { get; set; }
        [Computed]
        public virtual TicketOffice TicketOffice { get; set; }
        public Transaction Clone() { return new Transaction(this); }
    }
}
