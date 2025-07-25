using DotnetCoreAPI.DataBase;
using DotnetCoreAPI.Model;
using DotnetCoreAPI.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DotnetCoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class EmployeeController(IEmployeeServices _services) : ControllerBase
    {

        [HttpGet("GetEmployeeList")]
        public async Task<IActionResult> GetEmployeeList()
        {
            return Ok(await _services.GetEmployeeList());
        }

        [HttpGet("{id}")]
        [HttpGet("GetEmployeeById/{id:int:range(1,100)}")]
        public async Task<ActionResult<Employee>> GetEmployeeDetails(int id)
        {
            Employee? emplDetails = await _services.GetEmployeeDetails(id);
            if (emplDetails != null)
            {
                return emplDetails;
            }
            else
            {
                return NotFound("Employee not found");
            }
        }

        //[HttpGet("GetEmployeeBasedOnGenderAge/Genders/{genders:alpha}/Age/{age}")]
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployeeBasedOnGenderAge([FromQuery(Name = "gen")] string genders, int age)
        {
            List<Employee> lst = await _services.GetEmployeeBasedOnGender(genders, age);
            if (lst != null)
            {
                return lst;
            }
            else
            {
                return NotFound("There is not data for the filter");
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> AddEmployess([FromForm] Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    int id = await _services.AddEmployess(emp);
                    return Ok(id);
                }
                else
                {
                    return BadRequest("Please check the form validation");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
