using CS.DAL.Interface;
using CS.DAL.Repository;
using CS.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.Services.Test.Unit
{
    [TestClass]
    public class CustomerCarServiceTest
    {
        [TestMethod]
        public async Task Getters()
        {
            var repo = new Mock<ICustomerCarRepository>();

            List<Customer_Car> list = new List<Customer_Car>(3);
            list.AddRange(new List<Customer_Car>(3) {
                new Customer_Car() { Id = 1, CustomerId = 1, StatusId = 1, Vin = "AVIW", RegNr = "ABC123" },
                new Customer_Car() { Id = 2, CustomerId = 2, StatusId = 2, Vin = "WYX", RegNr = "OY223" },
                new Customer_Car() { Id = 2, CustomerId = 3, StatusId = 3, Vin = "ZZZ", RegNr = "CDF532" }
                });

            repo.Setup(x => x.GetByRegNumber("ABC")).Returns(Task.FromResult(new List<Customer_Car>(3) {
                new Customer_Car() { Id = 1, CustomerId = 1, StatusId = 1, Vin = "AVIW", RegNr = "ABC123" }
                }));

            repo.Setup(x => x.GetByVin("WYX")).Returns(Task.FromResult(new List<Customer_Car>(3) {
                new Customer_Car() { Id = 1, CustomerId = 1, StatusId = 1, Vin = "AVIW", RegNr = "ABC123" }
                }));

            repo.Setup(x => x.GetByCustomerName("Jhon")).Returns(Task.FromResult(new List<Customer_Car>(3) {
                new Customer_Car() { Id = 1, CustomerId = 1, StatusId = 1, Vin = "AVIW", RegNr = "ABC123" }
                }));

            var service = new CustomerCarService(repo.Object);

            var regNuberResult = await service.GetByRegNumber("ABC");
            var vinResult = await service.GetByVin("WYX");
            var customerResult = await service.GetByCustomerName("Jhon");


            Assert.IsTrue(regNuberResult.Count == 1,$"Returned: {regNuberResult.Count.ToString()}");
            Assert.IsTrue(vinResult.Count == 1, $"Returned: {vinResult.Count.ToString()}");
            Assert.IsTrue(customerResult.Count == 1, $"Returned: {customerResult.Count.ToString()}");
        }
    }
}
