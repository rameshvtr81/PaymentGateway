using PaymentGatewayApp.Models;
using PaymentGatewayApp.Providers.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Repositories
{
    public class BanksRepository : IDataRepository<Bank>
    {
        private AppDBContext _dbContext;

        public BanksRepository(AppDBContext context)
        {
            _dbContext = context;
        }


        public int Add(Bank entity)
        {
            _dbContext.Banks.Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(Bank entity)
        {
            _dbContext.Banks.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public Bank Get(int id)
        {
            return _dbContext.Banks.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Bank> GetAll()
        {
            return _dbContext.Banks.AsQueryable();
        }

        public int Update(Bank dbEntity, Bank entity)
        {
            dbEntity.Name = entity.Name;
            return _dbContext.SaveChanges();
        }

    }
}
