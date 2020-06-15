﻿using Microsoft.VisualBasic;
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
           TransactionDetail = new List<TransactionDetail>();
        }
        public Transaction(Transaction transaction)
        {
            this.Id = transaction.Id;
            this.DateVenta = transaction.DateVenta;
            this.KeyTaq = transaction.KeyTaq;
            this.ShiftTypeId = transaction.ShiftTypeId;
            this.Inter = transaction.Inter;
            this.InterSap = transaction.InterSap;
            this.Status = transaction.Status;
            this.TransactionDetail = new List<TransactionDetail>();
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
        public virtual List<TransactionDetail> TransactionDetail { get; set; }


        public Transaction Clone() { return new Transaction(this); }
    }
}
