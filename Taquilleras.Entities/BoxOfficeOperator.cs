using System;
using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Taquilleras.Entities
{
    [Table("BoxOfficeOperator")]
    public class BoxOfficeOperator:User
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TicketOfficeId { get; set; }
        public int ShiftTypeId { get; set; }
        public string Expedient { get; set; }

    }
}
