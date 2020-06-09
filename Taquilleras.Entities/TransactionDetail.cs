using System;
using System.Collections.Generic;
namespace Taquilleras.Entities
{
    [Dapper.Contrib.Extensions.Table("TransactionDetail")]
    public partial class TransactionDetail
    {
        
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int MovementTypeId { get; set; }
        public string InvalidValue { get; set; }
        public decimal? Received { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        //public virtual ActionType MovementType { get; set; }
        //public virtual Product Product { get; set; }
        //public virtual Transaction Transaction { get; set; }
    }
}
