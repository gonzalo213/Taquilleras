using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Models
{
    public partial class Product
    {
        public Product()
        {
            TransactionDetail = new HashSet<TransactionDetail>();
        }

        public int IdProduct { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}
