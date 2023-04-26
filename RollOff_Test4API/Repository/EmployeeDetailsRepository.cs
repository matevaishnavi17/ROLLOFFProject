using Microsoft.EntityFrameworkCore;
using RollOff_Test4API.Data;

using RollOff_Test4API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    public class EmployeeDetailsRepository: IEmployeeDetails
    {
        private RollOff4DbContext _db;
        public EmployeeDetailsRepository(RollOff4DbContext userDb)
        {
            _db = userDb;
        }
        #region GetAllEmployeeDetails
        public async Task<IEnumerable<Employee>> GetAllEmployeeDetails()
        {
            return await _db.Employees.ToListAsync();
        }
        #endregion

        public async Task<Employee> GetEmployeeByID(int ID)
        {
           return await _db.Employees.FirstOrDefaultAsync(x => x.GlobalGroupID == ID);
        }


        //retrive data by employee data by name email

        public async Task<IEnumerable<Employee>> GetEmployee(string data)
        {
            //var id = data;
            var Empquery = from x in _db.Employees select x;
            if(!string.IsNullOrEmpty(data))
            {
                Empquery = Empquery.Where(x => x.Name.Contains(data) || x.Email.Contains(data)||x.GlobalGroupID.ToString().Contains(data));
            }
            return await Empquery.AsNoTracking().ToListAsync();
        }

    }
}

