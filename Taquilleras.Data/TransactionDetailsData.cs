using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Taquilleras.Entities;

namespace Taquilleras.Data
{
    public class TransactionDetailsData:EntityManager<TransactionDetail>
    {
        private readonly IDbConnectionFactory _factory;
        public TransactionDetailsData(IDbConnectionFactory factory) : base(factory)
        {

            _factory = factory;
        }
        public int AddRange(ICollection<TransactionDetail> details)
        {
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                foreach (TransactionDetail detail in details)
                {
                    db.InsertAsync<TransactionDetail>(detail).Wait();
                }
            }
            return 1;
        }
        public List<TransactionDetail> GetByTransaction(int transactionId)
        {
            ICollection<TransactionDetail> transactionsDetails = new HashSet<TransactionDetail>();
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                string sql = string.Format(@"select * from dbo.TransactionDetail details where details.TransactionId = '{0}'", transactionId);
                return this.GetBySQL(sql).Result.ToList();
            }
            
        }
    }
}
