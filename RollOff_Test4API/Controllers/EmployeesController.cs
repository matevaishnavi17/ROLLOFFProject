using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Services;

namespace RollOff_Test4API.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        #region Employee

        #endregion
        private readonly EmployeeService _context;
        private readonly IMapper _mapper;

        public EmployeesController(EmployeeService context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Employees

        [HttpGet]
        [Route("[controller]")]

        //method for retriving employee details
        public async Task<IActionResult> GetDetails()
        {
            var data= await _context.GetAllEmployeeDetails();
            return Ok(_mapper.Map<List<Models.DTO.GetEmployee>>(data));
        }
       [HttpGet]
        [Route("[controller]/{id:int}")]
    //methos for retriving employee by id
        public async Task<IActionResult> GetEmployeeByID(int id)
        {
            var result=await _context.GetEmployeeByID(id);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Id not found");
            }
            return Ok(result);
        }
       [HttpGet]
        [Route("[controller]/{data}")]

        //retrive data by employee data by name/email/id
        public async Task<IActionResult> GetEmployee([FromRoute] string data)
        {
            //fetch employee
            var result = await _context.GetEmployee(data);
            try
            {
                if (result == null)
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Employee not found");
            }
            var resultDTO = _mapper.Map<List<Models.DTO.GetEmployeeByID>>(result);
            return Ok(resultDTO);
        }
     


        
    }
}
