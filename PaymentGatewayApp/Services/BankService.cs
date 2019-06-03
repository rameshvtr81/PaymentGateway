using PaymentGatewayApp.Models;
using PaymentGatewayApp.Providers.interfaces;
using PaymentGatewayApp.Services.interfaces;
using System;
using System.Linq;

namespace PaymentGatewayApp.Services
{
    public class BankService : IBankService
    {
        private IDataRepository<Bank> _repo;

        public BankService(IDataRepository<Bank> repository)
        {
            _repo = repository;
        }

        public int Add(Bank entity)
        {
            if(entity == null)
            {
                throw new ArgumentException("parameter cannot be null");
            }
            return _repo.Add(entity);
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

        public Bank Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be 0");
            }
            return _repo.Get(id);
        }

        public IQueryable<Bank> GetAll()
        {
            return _repo.GetAll();
        }

        public int Update(Bank entity)
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
