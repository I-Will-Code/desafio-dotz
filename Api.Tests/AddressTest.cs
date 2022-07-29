using Api.Controllers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests
{
    [TestClass]
    public class AddressTest : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            var user3 = _repository.User.Create(new User()
            {
                Email = "blu1000grau",
                Password = "2233*&"
            });

            var user4 = _repository.User.Create(new User()
            {
                Email = "jorge_1989",
                Password = "$%^$^hhh"
            });

            var user5 = _repository.User.Create(new User()
            {
                Email = "marcos.paulo",
                Password = "##@avss"
            });

            _repository.Address.Create(new Address()
            {
                Description = "Rua XV de Novembro, 1884, Centro, Blumenau/SC",
                User = user3
            });

            _repository.Address.Create(new Address()
            {
                Description = "Rua Guabiruba, 35, Velha, Blumenau/SC",
                User = user3
            });

            _repository.Address.Create(new Address()
            {
                Description = "Rua Pomerode, 455, Centro, Timbó/SC",
                User = user4
            });

            _repository.Address.Create(new Address()
            {
                Description = "Rua 7 de setembro, 3422, Centro, Blumenau/SC",
                User = user4
            });
        }

        [TestMethod]
        public void Create_New_Valid_Address()
        {
            var controller = new AddressesController(_repository);
            var user = _repository.User.FindByCondition(cond => cond.Email == "marcos.paulo").First();
            var address = new Address()
            {
                Description = "Rua Bahia, 3422, Passo Manso, Blumenau/SC",
                User = user
            };

            var response = controller.Post(address);
            var responseObject = (response.Result as OkObjectResult).Value as Address;
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
            Assert.AreEqual(responseObject.User, user);
        }

        [TestMethod]
        public void Update_Valid_Address()
        {
            const string updatedValue = "Address Updated!!";

            var controller = new AddressesController(_repository);
            var address = _repository.Address.FindById(2);
            address.Description = updatedValue;

            var response = controller.Put(address);
            var responseObject = (response.Result as OkObjectResult).Value as Address;
            Assert.AreEqual(responseObject.Description, updatedValue);
        }

        [TestMethod]
        public void Delete_Address()
        {
            var controller = new AddressesController(_repository);
            var response = controller.Delete(1);
            bool result = (bool)(response.Result as OkObjectResult).Value;
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete_Nonexisting_Address()
        {
            var controller = new AddressesController(_repository);
            var response = controller.Delete(999);
            Assert.IsInstanceOfType(response.Result, typeof(NotFoundResult));
        }
    }
}
