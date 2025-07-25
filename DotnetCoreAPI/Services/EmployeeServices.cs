using DotnetCoreAPI.DataBase;
using DotnetCoreAPI.Model;
using DotnetCoreAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DotnetCoreAPI.Services
{
    public class EmployeeServices: IEmployeeServices
    {
        private AppDbContext _dbContext;
        public EmployeeServices(AppDbContext dbcontext) 
        {
            _dbContext = dbcontext;
        }

        public async Task<List<Employee>> GetEmployeeList()
        {
            return await _dbContext.Employees.Where(m => !m.IsDeleted).ToListAsync();
        }

        public async Task<Employee> GetEmployeeDetails(int id)
        {
            return await _dbContext.Employees.Where(m => !m.IsDeleted && m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmployeeBasedOnGender(string genders, int age)
        {
            return await _dbContext.Employees.Where(m => m.Gender == genders && m.Age > age).ToListAsync();
        }

        public async Task<int> AddEmployess(Employee emp)
        {
            await _dbContext.Employees.AddAsync(emp);
            _dbContext.SaveChanges();
            return emp.Id;
        }
    }
}
