using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Model
{
    public partial class Bitacora
    {
        public int BitacoraId { get; set; }
        public int TableId { get; set; }
        public int RecordId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public virtual Table Table { get; set; }
    }
}
