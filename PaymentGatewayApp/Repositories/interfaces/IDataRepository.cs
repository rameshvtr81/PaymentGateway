using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Providers.interfaces
{
    public interface IDataRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(int id);
        int Add(TEntity entity);
        int Update(TEntity dbEntity, TEntity entity);
        int Delete(TEntity entity);
    }
}
