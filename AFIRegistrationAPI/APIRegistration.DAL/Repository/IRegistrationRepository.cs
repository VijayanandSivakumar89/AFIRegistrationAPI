using AFIRegistrationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIRegistrationAPI.APIRegistration.DAL.Repository
{
    public interface IRegistrationRepository
    {
        Customer GetById(int id);
        Customer Register(Customer customer);
    }
}
