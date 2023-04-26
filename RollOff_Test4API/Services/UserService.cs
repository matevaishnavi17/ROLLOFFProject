using RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AddUser(User u)
        {
            return await _userRepository.AddUser(u);
        }
    }
}
