using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SoutienScolaireV1.Azure.Models;

namespace SoutienScolaireV1.Azure
{
    public class TurkeyTime
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<TurkeyTime> _logger;

        public TurkeyTime(ApplicationDbContext dbContext, ILogger<TurkeyTime> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [Function("get_employees")]
        public async Task<IActionResult> GetEmployees([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "employee")] HttpRequest req)
        {
            _logger.LogInformation("Called get_employees with GET request");
            var employees = await _dbContext.Employees.ToListAsync();
            return new OkObjectResult(employees);
        }

        [Function("get_employee_byID")]
        public async Task<IActionResult> GetEmployeeById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "employee/{id}")] HttpRequest req, int id)
        {
            _logger.LogInformation("Called get_employee_byID with GET request");
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (employee == null) return new NotFoundResult();
            return new OkObjectResult(employee);
        }

        [Function("add_employee")]
        public async Task<IActionResult> AddEmployee([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "employee")] HttpRequest req)
        {
            _logger.LogInformation("Called add_employee with POST request");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var employee = JsonConvert.DeserializeObject<Employee>(requestBody);
            await _dbContext.Employees.AddAsync(employee);
            return new OkObjectResult(employee);
        }

        [Function("delete_employee")]
        public async Task<IActionResult> DeleteEmployee([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "employee/{id}")] HttpRequest req, int id)
        {
            _logger.LogInformation("Called delete_employee with DELETE request.");
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (employee == null) return new NotFoundResult();
            _dbContext.Employees.Remove(employee);
            return new OkResult();
        }
    }
}
