using Projects.Models;

namespace Projects.Data.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Task<Customer> GetById(Guid id);
        Task Update(Guid id, Customer newCustomer);
        Task Delete(Guid id);
        Task Create(Customer customer);
    }
}
