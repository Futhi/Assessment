using Microsoft.EntityFrameworkCore;
using Projects.Models;

namespace Projects.Data.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly ProjectsDbContext _context;

        public CustomerService(ProjectsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            var results = _context.Customers.ToList();
            return results;
        }
        public async Task<Customer> GetById(Guid id)
        {
            var customerDetails = await _context.Customers.FirstOrDefaultAsync(n => n.id == id);
            return customerDetails;
        }

        public async Task Update(Guid id, Customer newData)
        {
            var dbCustomer = await _context.Customers.FirstOrDefaultAsync(n => n.id == id);

            if (dbCustomer != null)
            {
                dbCustomer.name = newData.name;
                dbCustomer.surname = newData.surname;
                dbCustomer.age = newData.age;
               
            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var dbCustomer = await _context.Customers.FirstOrDefaultAsync(n => n.id == id);
            _context.Customers.Remove(dbCustomer);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Customer customer)
        {
            var newCustomer = new Customer()
            {
                id = Guid.NewGuid(),
                name = customer.name,
                surname = customer.surname,
                age = customer.age
            };
            await _context.Customers.AddAsync(newCustomer);
            await _context.SaveChangesAsync();
        
        }
    }
}
