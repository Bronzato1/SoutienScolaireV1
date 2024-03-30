using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SoutienScolaireV1.Azure.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace SoutienScolaire.Azure
{
    public class TurkeyTime
    {
        private readonly ApplicationDbContext _dbContext;

        public TurkeyTime(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [FunctionName("get_employees")]
        public async Task<IActionResult> GetEmployees([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "employee")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Called get_employees with GET request");
            var employees = await _dbContext.Employees.ToListAsync();
            return new OkObjectResult(employees);
        }

        [FunctionName("get_employee_byID")]
        public async Task<IActionResult> GetEmployeeById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "employee/{id}")] HttpRequest req, ILogger log, int id)
        {
            log.LogInformation("Called get_employee_byID with GET request");
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (employee== null) return new NotFoundResult();
            return new OkObjectResult(employee);
        }

        [FunctionName("add_employee")]
        public async Task<IActionResult> AddEmployee([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "employee")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Called add_employee with POST request");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var employee = JsonConvert.DeserializeObject<Employee>(requestBody);
            await _dbContext.Employees.AddAsync(employee);
            return new OkObjectResult(employee);
        }

        [FunctionName("delete_employee")]
        public async Task<IActionResult> DeleteEmployee([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "employee/{id}")] HttpRequest req, ILogger log, int id)
        {
            log.LogInformation("Called delete_employee with DELETE request.");
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(f => f.Id.Equals(id));
            if (employee == null) return new NotFoundResult();
            _dbContext.Employees.Remove(employee);
            return new OkResult();
        }
    }
}
