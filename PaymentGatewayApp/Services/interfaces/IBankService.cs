using PaymentGatewayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Services.interfaces
{
    public interface IBankService
    {
        IQueryable<Bank> GetAll();
        Bank Get(int id);
        int Add(Bank entity);
        int Update(Bank entity);
        int Delete(int ID);
    }
}
