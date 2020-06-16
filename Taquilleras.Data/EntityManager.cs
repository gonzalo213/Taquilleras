using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Taquilleras.Data
{
    public class EntityManager<T> : IDataManager<T>
      where T : class
    {

        private readonly IDbConnectionFactory _factory;

        public EntityManager(IDbConnectionFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Metodo que agrega los cambios a la coleccion de entidades.
        /// </summary>
        /// <returns>entity</returns>
        public async virtual Task<T> CreateAsync(T entity)
        {
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                await db.InsertAsync<T>(entity);

                return entity;
            }
        }
        public async virtual Task<T> GetAsync(int? id)
        {
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
              var result= await db.GetAsync<T>(id);
                return result;
            }
        }
        public async virtual Task UpdateAsync(T entity)
        {
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                await db.UpdateAsync<T>(entity);
            }
        }
        /// <summary>
        /// Metodo que llena la lista con una colección
        /// </summary>
        /// <returns></returns>
        public async virtual Task<IEnumerable<T>> GetAllAsync()
        {
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                return await db.GetAllAsync<T>();
            }
        }

        public async virtual Task<IEnumerable<T>> GetBySQL(string sql )
        {
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                return await db.QueryAsync<T>(sql);
            }
        }

        public async virtual Task<T> GetByID(int id)
        {
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                return await db.GetAsync<T>(id);
            }
        }

    }
}
