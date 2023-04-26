using RollOff_Test4API.Data;
using RollOff_Test4API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    public class UserRepository : IUserRepository
    {
        private RollOff4DbContext _context;
        public UserRepository(RollOff4DbContext context)
        {
            _context = context;
        }
        #region Register User

        
        public async Task<User> AddUser(User u)
        {
            if (_context.Users.Where(user => user.Email == u.Email).FirstOrDefault() != null)
            {
                return null;
            }
            await _context.AddAsync(u);
            await _context.SaveChangesAsync();
            return u;
        }

        #endregion
    }
}
