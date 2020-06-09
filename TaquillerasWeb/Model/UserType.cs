﻿using System;
using System.Collections.Generic;

namespace TaquillerasWeb.Model
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
