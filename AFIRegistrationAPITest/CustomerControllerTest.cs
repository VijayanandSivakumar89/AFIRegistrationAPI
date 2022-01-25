using AFIRegistrationAPI.APIRegistration.DAL.Repository;
using AFIRegistrationAPI.Controllers;
using AFIRegistrationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace AFIRegistrationAPITest
{
    public class CustomerControllerTests
    {
        private readonly Mock<IRegistrationRepository> _mockRepo;
        private readonly CustomersController _controller;
        
        /// <summary>
        /// Mocking the Controller and Respository using DI object
        /// </summary>
        public CustomerControllerTests()
        {
            _mockRepo = new Mock<IRegistrationRepository>();
            _controller = new CustomersController(_mockRepo.Object);
        }

        /// <summary>
        /// To check if the GetCustomer method returns correct result with valid input
        /// </summary>
        [Fact]
        public void Get_Returns_OkResult()
        {
            _mockRepo.Setup(service => service.GetById(1))
            .Returns(new Customer() { Id=1});
            var controllerResult= _controller.GetCustomer(1) as OkObjectResult;
            Assert.IsType<Customer>(controllerResult.Value);
            
            Assert.Equal(1, (controllerResult.Value as Customer).Id );
                         
        }

        /// <summary>
        /// To check if GetCustomer returns NotFound Result with Invalid Input
        /// </summary>

        [Fact]
        public void Get_Returns_NotFoundResult()
        {
            var result = _controller.GetCustomer(10);
            Assert.IsType<NotFoundResult>(result);
        }

        /// <summary>
        /// Post method returns bad request on invalid Input
        /// </summary>
        [Fact]
        public void Post_ReturnsBadRequest()
        {
            var missingItem = new Customer()
            {
                Surname = "Test",
                DateOfBirth = new DateTime(2000,10,12),
                Email="yyyy@gmail.com",
                PolicyNumber="XX-123456"
            };
            _controller.ModelState.AddModelError("Firstname", "Firstname is a Required field");
           
            var response = _controller.PostCustomer(missingItem);
            
            Assert.IsType<BadRequestResult>(response);
        }

        /// <summary>
        /// To see if post method returns valid response on valid input
        /// </summary>
        [Fact]
        public void Post_ReturnsCreatedResponse()
        {
            var completeItem = new Customer()
            {
                Firstname="wyiiu",
                Surname = "Test",
                DateOfBirth = new DateTime(2000, 10, 12),
                Email = "yyyy@gmail.com",
                PolicyNumber = "XX-123456"
            };

            var response = _controller.PostCustomer(completeItem);
            Assert.IsType<CreatedAtActionResult>(response);

            //value of the result
            var item = response as CreatedAtActionResult;
            Assert.IsType<Customer>(item.Value);

            //check value of this customer
            var newItem = item.Value as Customer;
            Assert.Equal(completeItem.Firstname, newItem.Firstname);
            Assert.Equal(completeItem.Email, newItem.Email);
        }



    }
} 
