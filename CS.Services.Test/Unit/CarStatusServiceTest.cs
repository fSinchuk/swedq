using CS.Models;
using CS.Services.Test.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CS.Services.Test.Unit
{

    [TestClass]
    public class CarStatusServiceTest
    {

        CarStatusRepositoryMock repo;

        [TestInitialize]
        public async Task Init() {
            repo = new CarStatusRepositoryMock();
            await repo.AddAsync(new Car_Status() { Id = 1, Name = "Active" });
            await repo.AddAsync(new Car_Status() { Id = 2, Name = "Broken" });
            await repo.AddAsync(new Car_Status() { Id = 3, Name = "Moving" });
        }

        [TestMethod]
        public async Task GetAllAsync() {

            //action
            var result = await repo.GetAll();

            //assert
            Assert.IsTrue(result.Count == 3,"List should contain 3 items");
        }

        [TestMethod]
        public async Task GetAllFailAsync()
        {
            //action
            var result = await repo.GetAll();

            //assert
            Assert.IsFalse(result.Count == 0, "List should contain 3 items");
        }

        [TestMethod]
        public async Task GetByIdAsync()
        {
            //action
            var result = await repo.GetByID(1);

            //assert
            Assert.IsTrue(result.Id == 1, "Item should have id:1");
        }

    }
}
