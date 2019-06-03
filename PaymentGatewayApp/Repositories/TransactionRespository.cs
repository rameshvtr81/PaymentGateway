using PaymentGatewayApp.Models;
using PaymentGatewayApp.Providers.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PaymentGatewayApp.Repositories
{
    public class TransactionRespository :IDataRepository<Transaction>
    {
        private AppDBContext _dbContext;

        public TransactionRespository(AppDBContext context)
        {
            _dbContext = context;
        }


        public int Add(Transaction entity)
        {
            _dbContext.Transactions.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Transaction entity)
        {
            _dbContext.Transactions.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public Transaction Get(int id)
        {
            return _dbContext.Transactions.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Transaction> GetAll()
        {
            return _dbContext.Transactions.AsQueryable();
        }

        public int Update(Transaction dbEntity, Transaction entity)
        {
            throw new NotImplementedException();
        }
    }
}
