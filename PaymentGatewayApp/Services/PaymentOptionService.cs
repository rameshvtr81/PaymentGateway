using PaymentGatewayApp.Models;
using PaymentGatewayApp.Providers.interfaces;
using PaymentGatewayApp.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Services
{
    public class PaymentOptionsService : IPaymentOptions
    {
        private IDataRepository<PaymentOption> _repo;

        public PaymentOptionsService(IDataRepository<PaymentOption> repository)
        {
            _repo = repository;
        }

        public int Add(PaymentOption entity)
        {
            if (entity == null)
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
            var option = _repo.Get(ID);
            return _repo.Delete(option);
            
        }

        public PaymentOption Get(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Id cannot be 0");
            }
            return _repo.Get(id);
        }

        public IQueryable<PaymentOption> GetAll()
        {
            return _repo.GetAll();
        }

        public int Update(PaymentOption newOption)
        {
            if (newOption == null)
            {
                throw new ArgumentException("parameter cannot be null");
            }
            var old = _repo.Get(newOption.ID);
            return _repo.Update(old, newOption);
            
        }
    }
}
