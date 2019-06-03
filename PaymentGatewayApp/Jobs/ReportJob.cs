using Hangfire;
using PaymentGatewayApp.Jobs.interfaces;
using PaymentGatewayApp.Models;
using PaymentGatewayApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Jobs
{
    public class ReportJob : IReportJob
    {

        private AppDBContext _dbcontext;
        
        public ReportJob(AppDBContext dBContext)
        {
            _dbcontext = dBContext;
        }

        public async Task Run(IJobCancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await RunAtTimeOf(DateTime.Now);
        }

        public Task RunAtTimeOf(DateTime dateTime)
        {
            return Task.Run(() =>
            {
                var Data = _dbcontext.Transactions
                            .Where(x => x.DateCreated.Date == dateTime.Date)
                            .Select(x => new TransactionsReport
                            {
                                TransactionsID=x.ID,
                                TransactionMethod = x.TransactionMethod,
                                BankName = x.BankName,
                                Cardnumber = x.Cardnumber,
                                Amount = x.Amount,
                                Reference = x.Reference,
                                MerchantId = x.MerchantId,
                                TransDate = x.DateCreated
                            })
                            .ToList();
                _dbcontext.TransReport.AddRange(Data);
                _dbcontext.SaveChanges();
            } );
        }
    }
}
