using Microsoft.EntityFrameworkCore;
using Projects.Models;

namespace Projects.Data.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly ProjectsDbContext _context;

        public EmployeeService(ProjectsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            var results = _context.Employees.ToList();
            return results;
        }
        public async Task<Employee> GetById(Guid id)
        {
            var projectDetails = await _context.Employees.FirstOrDefaultAsync(n => n.id == id);
            return projectDetails;
        }

        public async Task Update(Guid id, Employee newData)
        {
            var dbEmployee = await _context.Employees.FirstOrDefaultAsync(n => n.id == id);

            if (dbEmployee != null)
            {
                dbEmployee.name = newData.name;
                dbEmployee.surname = newData.surname;
           

            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var dbEmployee = await _context.Employees.FirstOrDefaultAsync(n => n.id == id);
            _context.Employees.Remove(dbEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Employee employee)
        {
            var newEmployee = new Employee()
            {
                id = Guid.NewGuid(),
                name = employee.name,
                surname = employee.surname
               
            };
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();

        }
    }
}
