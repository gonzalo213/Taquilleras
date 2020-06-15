using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;
namespace Taquilleras.Entities
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            TransactionDetail = new HashSet<TransactionDetail>();
        }
        [Key]
        public int IdProduct { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}
