using PaymentGatewayApp.Models;
using PaymentGatewayApp.Providers.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Repositories
{
    public class PaymentOptionDataRepository : IDataRepository<PaymentOption>
    {
        private AppDBContext _dbContext;

        public PaymentOptionDataRepository(AppDBContext context)
        {
            _dbContext = context;
            _dbContext.SaveChanges();
        }


        public int Add(PaymentOption entity)
        {
            _dbContext.PaymentOptions.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(PaymentOption entity)
        {
            _dbContext.PaymentOptions.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public PaymentOption Get(int id)
        {
            return _dbContext.PaymentOptions.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<PaymentOption> GetAll()
        {
            return _dbContext.PaymentOptions.AsQueryable();
        }

        public int Update(PaymentOption dbEntity, PaymentOption entity)
        {
            dbEntity.Name = entity.Name;
            return _dbContext.SaveChanges();
        }

        
    }
}
