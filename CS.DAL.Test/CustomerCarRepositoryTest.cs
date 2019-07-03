using CS.DAL.Repository;
using CS.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CS.DAL.Test
{
    [TestClass]
    public class CustomerCarRepositoryTest
    {
        [TestMethod]
        public async Task GetCustomerByName() {
            //using (var context = Helpers.GetContext("CustomerCarContext"))
            //{
            //    context.AddRange(new Customer[]
            //    {
            //        new Customer(){ Id=1, Name="Anna", Address="Stockholm" },
            //        new Customer(){ Id=2, Name="John", Address="Malmo" },
            //        new Customer(){ Id=3, Name="Sara", Address="Gothenburg" },

            //    });

            //    await context.SaveChangesAsync();
            //}

            //using (var context = Helpers.GetContext("LastNameCaseTest"))
            //{
            //    var repo = new Repository<Customer_Car>(context);

            //    Assert.AreEqual(6, (await repo.Get()).Count);
            //    Assert.AreEqual(5, (await repo.GetByCustomerPartialLastName("smith")).Count);
            //    Assert.AreEqual(1, (await repo.GetByCustomerPartialLastName("MC")).Count);

            //}

        }

    }
}
