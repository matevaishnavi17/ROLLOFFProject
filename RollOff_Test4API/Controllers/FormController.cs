using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RollOff_Test4API.Models.Domain;
using RollOff_Test4API.Models.DTO;
using RollOff_Test4API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFeedbackFormRepository formRepository;
        private readonly IMapper mapper;

        public FormController(IFeedbackFormRepository formRepository, IMapper mapper)
        {
            this.formRepository = formRepository;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployeeForm(FeedbackFormDTO formTable)
        {
            //DTO to Model
            var employeeForm = mapper.Map<FeedbackForm>(formTable);

            //Pass Detail to Repository
            var response = await formRepository.AddFormAsync(employeeForm);

            //Convert back to DTO
            var formTableDTO = mapper.Map<FeedbackFormDTO>(response);

            return Ok(formTableDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeesForms()
        {
            var formDetails = await formRepository.GetAllFormsAsync();

            //return DTO

            var formDetailsDTO = mapper.Map<List<FeedbackFormDTO>>(formDetails);

            return Ok(formDetailsDTO);
        }

        [HttpDelete]
        [Route("{ggid}")]
        public async Task<IActionResult> DeleteEmployeeForm(double ggid)
        {
            var employee = await formRepository.DeleteFormAsync(ggid);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPut]
        [Route("{ggid}")]
        public async Task<IActionResult> UpdateEmployeeForm(double ggid, FeedbackFormDTO updateFormDTO)
        {
            var employee = mapper.Map<FeedbackForm>(updateFormDTO);
            var emp = await formRepository.UdateFormAsync(ggid, employee);
            if (emp == null)
            {
                return NotFound();
            }
            var empDTO = mapper.Map<FeedbackFormDTO>(emp);
            return Ok(empDTO);

        }

    }
}
