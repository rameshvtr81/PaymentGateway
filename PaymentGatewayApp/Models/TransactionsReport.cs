using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayApp.Models
{
    public class TransactionsReport
    {
        [Key]
        public int ID { get; set; }
        public int TransactionsID { get; set; }
        public string TransactionMethod { get; set; }        
        public string BankName { get; set; }
        public string Cardnumber { get; set; }
        public int CVV { get; set; }
        public double Amount { get; set; }
        public string Reference { get; set; }
        public string MerchantId { get; set; }

        public DateTime TransDate { get; set; }

        public DateTime Createddate
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;
    }
}
