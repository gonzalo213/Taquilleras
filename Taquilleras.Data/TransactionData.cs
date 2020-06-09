using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Taquilleras.Entities;

namespace Taquilleras.Data
{
    public class TransactionData : EntityManager<Transaction>
    {

        private readonly IDbConnectionFactory _factory;

        public TransactionData(IDbConnectionFactory factory) : base(factory)
        {

            _factory = factory;
        }

        public int AddCompleate(Transaction transaction)
        {
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                db.InsertAsync<Transaction>(transaction).Wait();
                ICollection<TransactionDetail> detailsTem = new HashSet<TransactionDetail>(); 
                foreach (TransactionDetail detail in transaction.TransactionDetail)
                    if (detail.Quantity > 0)
                    {
                        detail.TransactionId = transaction.Id;
                        detailsTem.Add(detail);
                    }
                TransactionDetailsData entity = new TransactionDetailsData(this._factory);
                entity.AddRange(detailsTem);
                return 1;
            }
        }

    }
}
