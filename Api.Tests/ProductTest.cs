using Api.Controllers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests
{
    [TestClass]
    public class ProductTest : TestBase
    {
        [TestMethod]
        public void List_Available_Products()
        {
            var controller = new ProductsController(_repository);
            var result = controller.Get().ToList();

            Assert.IsTrue(result.Count == 3);
        }

        [TestInitialize]
        public void Init()
        {
            _repository.Product.Create(new Product()
            {
                Description = "Margarina Doriana 150g"
            });

            _repository.Product.Create(new Product()
            {
                Description = "Creme Dental Colgate"
            });

            _repository.Product.Create(new Product()
            {
                Description = "Listerine 1lt"
            });
        }
    }
}
