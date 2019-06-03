using PaymentGatewayApp.Models;
using PaymentGatewayApp.Providers.interfaces;
using PaymentGatewayApp.Services.interfaces;
using System;
using System.Linq;

namespace PaymentGatewayApp.Services
{
    public class TransactionService:ITransactionService
    {
        private IDataRepository<Transaction> _repo;

        public TransactionService(IDataRepository<Transaction> repository)
        {
            _repo = repository;
        }

        public int Add(Transaction entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("parameter cannot be null");
            }
            if(entity.TransactionMethod!= "Debit/Credit Card")
            {
                entity.Cardnumber = null;
                entity.CVV = 0;
            }
            return _repo.Add(entity);
            //_repo.SaveChanges();
        }

        public int Delete(int ID)
        {
            if (ID <= 0)
            {
                throw new ArgumentException("Id cannot be 0");
            }
            var old = _repo.Get(ID);
            return _repo.Delete(old);
        }

        public Transaction Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be 0");
            }
            return _repo.Get(id);
        }

        public IQueryable<Transaction> GetAll()
        {
            return _repo.GetAll();
        }

        public int Update(Transaction entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("parameter cannot be null");
            }
            var old = _repo.Get(entity.ID);
            return _repo.Update(old, entity);
        }
    }
}
