using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NurseryAngularApplication.Model.Employee.Dto;

namespace NurseryAngularApplication.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        [HttpGet]
        [Route("GetAllEmployee")]
        public async Task<ActionResult<IEnumerable<EmployeeListDto>>> GetAllEmployees(int? NurseryId)
        {
            return await _employeeRepository.GetAllEmployee(NurseryId);
        }


        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployees(CreateorEditEmployeeDto input)
        {

            try
            {
                var postId = await _employeeRepository.AddEmployee(input);
                if (postId > 0)
                {
                    return Ok(postId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }

        }


        [HttpGet]
        [Route("GetEditEmployee")]
        public async Task<ActionResult<EmployeeListDto>> GetEditEmployee(int Id)
        {
            return await _employeeRepository.EditEmployee(Id);
        }

        [HttpPost]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployees(int EmployeeId)
        {
            int result = 0;

            if (EmployeeId == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await _employeeRepository.DeleteEmployee(EmployeeId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployees(CreateorEditEmployeeDto input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepository.UpdateEmployee(input);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

    }
}
