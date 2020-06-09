using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Taquilleras.Data
{
    public interface IDbConnectionFactory
    {
        DbConnection CreateConnection(string connectionStringName);
    }
}
