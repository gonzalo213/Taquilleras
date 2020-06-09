using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Model
{
    public partial class ActionType
    {
        public ActionType()
        {
            TransactionDetail = new HashSet<TransactionDetail>();
        }

        public int IdTipoMovimiento { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TransactionDetail> TransactionDetail { get; set; }
    }
}
