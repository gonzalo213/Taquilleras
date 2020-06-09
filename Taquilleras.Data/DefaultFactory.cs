using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Taquilleras.Data
{
    public class DefaultFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly Func<DbConnection> _factory;

        public DefaultFactory(IConfiguration configuration, Func<DbConnection> factory)
        {
            _configuration = configuration;
            _factory = factory;
        }
        public DbConnection CreateConnection(string connectionStringName)
        {
            string connectionString = _configuration.GetConnectionString(connectionStringName);
            var connection = _factory();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}
