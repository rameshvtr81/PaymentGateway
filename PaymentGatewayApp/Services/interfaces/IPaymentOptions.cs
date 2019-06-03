using PaymentGatewayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Services.interfaces
{
    public interface IPaymentOptions
    {
        IQueryable<PaymentOption> GetAll();
        PaymentOption Get(int id);
        int Add(PaymentOption entity);
        int Update(PaymentOption entity);
        int Delete(int ID);
    }
}
