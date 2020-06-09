using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Taquilleras.Data;

namespace TaquillerasWeb
{
    public static class Extensors
    {

        public static IServiceCollection AddDbConnectionFactory(
            this IServiceCollection services,
            Func<IServiceProvider, DbConnection> factory, Microsoft.Extensions.Configuration.IConfiguration configuration,
            ServiceLifetime lifetime = ServiceLifetime.Scoped)
        {

            object factoryWrapper(IServiceProvider x) => new DefaultFactory(configuration, () => factory(x));

            services.TryAdd(new ServiceDescriptor(typeof(IDbConnectionFactory), factoryWrapper, lifetime));
            return services;
        }

    }
}
