using RollOff_Test4API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User u);
        
    }
}
