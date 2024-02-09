using EmployeeManagementSystemAPI.Model;
using EmployeeManagementSystemAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployee()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id) 
        { 
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if(employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var addedEmployee = await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(AddEmployee), new { id = addedEmployee.Id}, addedEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee) 
        {
            if (id != employee.Id)
                return BadRequest("Invalid employee ID.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
            return Ok(updatedEmployee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id) 
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (!result)
                return NotFound();
            return Ok(result);
        }
    }
}
