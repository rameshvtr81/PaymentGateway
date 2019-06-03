using Moq;
using PaymentGatewayApp.Models;
using PaymentGatewayApp.Providers.interfaces;
using PaymentGatewayApp.Repositories;
using PaymentGatewayApp.Services;
using PaymentGatewayApp.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Paymentgateway.test
{
    public class BankServiceTest
    {
        private Mock<IDataRepository<Bank>> _mockRepository;      
        private IBankService _service;

        List<Bank> listbank;

        public BankServiceTest()
        {
            Initialize();
        }

        [Fact]
        public void Initialize()
        {
            _mockRepository = new Mock<IDataRepository<Bank>>();
            listbank = new List<Bank>
            {
                new Bank
                {
                    ID=1,
                    Name="Maybank"
                },
                new Bank
                {
                    ID =2,
                    Name="CIMB Bank"
                },
                new Bank
                {
                    ID=3,
                    Name="RHB Bank"
                }
            };

            _service = new BankService(_mockRepository.Object);


        }

        [Fact]
        public void Bank_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(listbank.AsQueryable());

            //Act
            var results = _service.GetAll();

            //Assert
            Assert.NotNull(results);
            Assert.Equal(3, results.Count());
        }


        [Fact]
        public void Bank_Get_Single()
        {
            //Arrange
            int id = 1;
            _mockRepository.Setup(x => x.Get(id)).Returns(listbank.FirstOrDefault(x => x.ID == id));

            //Act
            var result = _service.Get(id);

            //Assert
            Assert.NotNull(result);
        }


        [Fact]
        public void Add_Bank()
        {
            //Arrange
            var bank = new Bank
            {
                ID = 4,
                Name = "Test Bank"
            };
            _mockRepository.Setup(x => x.Add(bank)).Returns(1);

            //Act
            var result = _service.Add(bank);

            //Assert.
            Assert.Equal(1,result);
        }


        [Fact]
        public void Add_Bank_With_Null_Value()
        {
            //Arrange
            int id = 1;
            var bank = new Bank
            {
                ID = 4,
                Name = "Test Bank"
            };
            _mockRepository.Setup(x => x.Add(bank)).Returns(1);

            //Act
            Action act = () => { var result = _service.Add(null); };

            //Assert.
            Assert.Throws<ArgumentException>(act);
        }
    }
}
