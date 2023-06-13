using Projects.Models;

namespace Projects.Data.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Task<Employee> GetById(Guid id);
        Task Update(Guid id, Employee newEmployee);
        Task Delete(Guid id);
        Task Create(Employee employee);
    }
}
