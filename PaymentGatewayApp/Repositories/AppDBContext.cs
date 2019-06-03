using Microsoft.EntityFrameworkCore;
using PaymentGatewayApp.Models;

namespace PaymentGatewayApp.Repositories
{
    public class AppDBContext: DbContext
    {
        public AppDBContext() { }
        public AppDBContext(DbContextOptions options):base(options){}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            modelBuilder.Entity<PaymentOption>().HasData
                (
                    new PaymentOption
                    {
                        ID = 1,
                        Name = "Online Banking"
                    },
                    new PaymentOption
                    {
                        ID = 2,
                        Name = "Gateway Wallet"
                    },
                    new PaymentOption
                    {
                        ID = 3,
                        Name = "Debit/Credit Card"
                    }
                );

            modelBuilder.Entity<Bank>().HasData(
                new Bank
                {
                    ID=1,
                    Name = "Maybank"
                },
                new Bank
                {
                    ID = 2,
                    Name = "CIMB Bank"
                },
                new Bank
                {
                    ID = 3,
                    Name = "Public Bank Berhad"
                },
                new Bank
                {
                    ID = 4,
                    Name = "RHB Bank"
                },
                new Bank
                {
                    ID = 5,
                    Name = "Hong Leong Bank"
                },
                new Bank
                {
                    ID = 6,
                    Name = "OCBC Bank Malaysia"
                },
                new Bank
                {
                    ID = 7,
                    Name = "HSBC Bank Malaysia"
                },
                new Bank
                {
                    ID = 8,
                    Name = "CitiBank Malaysia"
                },
                new Bank
                {
                    ID = 9,
                    Name = "Bank Muamalat Malaysia Berhad"
                },
                new Bank
                {
                    ID = 10,
                    Name = "Alliance Bank"
                }
                );
        }


        //dbsets
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionsReport> TransReport { get; set; }

        
    }
}
