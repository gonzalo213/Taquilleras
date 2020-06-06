using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Models
{
    public partial class Table
    {
        public Table()
        {
            Bitacora = new HashSet<Bitacora>();
        }

        public int TableId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Bitacora> Bitacora { get; set; }
    }
}
