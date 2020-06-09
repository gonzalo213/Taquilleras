using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Model
{
    public partial class User
    {
        public int Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int? UserTypeId { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
