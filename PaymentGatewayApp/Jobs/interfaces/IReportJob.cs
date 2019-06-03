using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Jobs.interfaces
{
    public interface IReportJob
    {
        Task RunAtTimeOf(DateTime dateTime);
    }
}
