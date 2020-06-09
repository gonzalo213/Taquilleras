using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Taquilleras.Entities
{
    [Dapper.Contrib.Extensions.Table("SaleTransaction")]
    public partial class Transaction
    {
        public Transaction()
        {
           TransactionDetail = new HashSet<TransactionDetail>();
        }

        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public int KeyTaq { get; set; }
        public int ShiftTypeId { get; set; }
        public DateTime? DateVenta { get; set; }
        public string Status { get; set; }
        public string Inter { get; set; }
        public string InterSap { get; set; }
        public decimal? TotalAmount { get; set; }
        [Dapper.Contrib.Extensions.Computed]
        public virtual ICollection<TransactionDetail> TransactionDetail { get; set; }

    }
}
