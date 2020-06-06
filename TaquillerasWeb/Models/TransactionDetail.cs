﻿using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Models
{
    public partial class TransactionDetail
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int MovementTypeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual ActionType MovementType { get; set; }
        public virtual Product Product { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
