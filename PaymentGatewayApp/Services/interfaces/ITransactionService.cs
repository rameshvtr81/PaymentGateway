using PaymentGatewayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Services.interfaces
{
    public interface ITransactionService
    {
        IQueryable<Transaction> GetAll();
        Transaction Get(int id);
        int Add(Transaction entity);
        int Update(Transaction entity);
        int Delete(int ID);
    }
}
