using Api.Context;
using Api.Controllers;
using Api.Models;
using Api.Repositories;
using Api.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Tests
{
    [TestClass]
    public class UserTests : TestBase
    {
        [TestInitialize]
        public void Init()
        {
            var user1 = _repository.User.Create(new User()
            {
                Email = "willwerling",
                Password = "2706!!"
            });

            var user2 = _repository.User.Create(new User()
            {
                Email = "jaqueline",
                Password = "9988!@"
            });

            _repository.Score.Create(new Score()
            {
                User = user1,
                Total = 300
            });

            _repository.Score.Create(new Score()
            {
                User = user2,
                Total = 1300
            });
        }

        [TestMethod]
        public void Authenticate_With_Valid_User()
        {
            var controller = new UsersController(_repository);
            var user = new User()
            {
                Email = "willwerling",
                Password = "2706!!"
            };

            var response = controller.Authenticate(user);
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Authenticate_With_Invalid_User()
        {
            var controller = new UsersController(_repository);
            var user = new User()
            {
                Email = "willwerling",
                Password = "2222"
            };

            var response = controller.Authenticate(user);
            Assert.IsInstanceOfType(response.Result, typeof(NotFoundObjectResult));
        }

        [TestMethod]
        public void Create_New_User()
        {
            var controller = new UsersController(_repository);
            var user = new User()
            {
                Email = "shurastey",
                Password = "#$aa18"
            };

            var response = controller.PostUser(user);
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Create_New_User_With_EF_Validation()
        {
            var controller = new UsersController(_repository);
            var user = new User()
            {
                Password = "#$aa18"
            };

            var response = controller.PostUser(user);
            Assert.IsInstanceOfType(response.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Update_Valid_User()
        {
            var controller = new UsersController(_repository);
            var user = new User()
            {
                Id = 1,
                Email = "shurastey updated",
                Password = "#$aa18_updated"
            };

            var response = controller.PutUser(user);
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Update_Nonexistent_User()
        {
            var controller = new UsersController(_repository);
            var user = new User()
            {
                Id = 999,
                Email = "shurastey updated",
                Password = "#$aa18_updated"
            };

            var response = controller.PutUser(user);
            Assert.IsInstanceOfType(response.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Get_Score_Balance()
        {
            /*const int userId = 1;
            var controller = new UsersController(_repository);
            var response = controller.GetScoreBalance(userId);
            var responseObject = (response.Result as OkObjectResult).Value as Score;
            
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
            Assert.AreEqual(responseObject.Total, 300);*/
        }

        [TestMethod]
        public void Get_Score_Extract()
        {
            /*const int userId = 1;
            var controller = new UsersController(_repository);
            var response = controller.GetScoreExtract(userId);
            var responseObject = (response.Result as OkObjectResult).Value as ScoreExtract;

            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
            //Assert.AreEqual(responseObject.Total, 300);*/
        }
    }
}
