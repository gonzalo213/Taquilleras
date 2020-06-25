using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;

namespace Taquilleras.Entities
{
    [Table("GeneralUser")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}
