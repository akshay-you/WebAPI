using DotnetCoreAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreAPI.ServiceInterface
{
    public interface IEmployeeServices
    {
        Task<List<Employee>> GetEmployeeList();
        Task<Employee> GetEmployeeDetails(int id);
        Task<List<Employee>> GetEmployeeBasedOnGender(string genders, int age);
        Task<int> AddEmployess(Employee emp);
    }
}
