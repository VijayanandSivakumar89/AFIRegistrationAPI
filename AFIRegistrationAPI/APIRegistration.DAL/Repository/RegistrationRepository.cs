using AFIRegistrationAPI.AFIRegistration.DAL;
using AFIRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIRegistrationAPI.APIRegistration.DAL.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly CustomerDBContext _context;

        public RegistrationRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public Customer GetById(int id)
        {
            return _context.Cust.Where(x=>x.Id==id).FirstOrDefault();
        }

        public Customer Register(Customer customer)
        {
            _context.Cust.Add(customer);

            _context.SaveChangesAsync();

            return customer;
        }
    }
}
