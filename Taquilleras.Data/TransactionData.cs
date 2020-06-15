﻿using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Taquilleras.Entities;

namespace Taquilleras.Data
{
    public class TransactionData : EntityManager<Transaction>
    {

        private readonly IDbConnectionFactory _factory;
        TransactionDetailsData detailsManger;

        public TransactionData(IDbConnectionFactory factory) : base(factory)
        {

            _factory = factory;            
        }

        public int AddCompleate(Transaction transaction)
        {
            detailsManger = new TransactionDetailsData(this._factory);
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
                detailsManger.AddRange(detailsTem);
                return 1;
            }
        }
        public ICollection<Transaction> Find(DateTime date, int ticketOfficeId)
        {
            ICollection<Transaction> transactions = new HashSet<Transaction>();
            detailsManger = new TransactionDetailsData(this._factory);
            using (var db = _factory.CreateConnection(Constants.ConnectionStringName))
            {
                string sql = string.Format(@"select * from dbo.SaleTransaction tra where tra.KeyTaq = '{0}' and tra.DateVenta = '{1}'", ticketOfficeId, date.ToString("yyyy-MM-dd"));
                transactions = this.GetBySQL(sql).Result.ToList();                
            }
            foreach (Transaction transaccion in transactions)
                transaccion.TransactionDetail=detailsManger.GetByTransaction(transaccion.Id);
            return transactions;
        }

    }
}
