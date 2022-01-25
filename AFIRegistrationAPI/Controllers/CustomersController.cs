using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AFIRegistrationAPI.AFIRegistration.DAL;
using AFIRegistrationAPI.Models;
using AFIRegistrationAPI.APIRegistration.DAL.Repository;

namespace AFIRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRegistrationRepository _repository;

        public CustomersController(IRegistrationRepository repository)
        {
            _repository = repository;
        }

                     
        // GET: api/Customers/5
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer =  _repository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

       

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var item = _repository.Register(customer);

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
            
   
        }

    }
}
