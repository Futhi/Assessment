using Projects.Models;

namespace Projects.Data
{
    public class ProjectsDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProjectsDbContext>();
                context.Database.EnsureCreated();

                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {
                            id = Guid.NewGuid(),
                            name = "Arisha",
                            surname="Barron",
                            age="18"
                        },
                        new Customer()
                        {
                            id = Guid.NewGuid(),
                            name = "Branden",
                            surname="Gibson",
                            age="35"
                        },
                        new Customer()
                        {
                            id = Guid.NewGuid(),
                            name = "Rhonda",
                            surname="Church",
                            age="31"
                        },
                        new Customer()
                        {
                            id = Guid.NewGuid(),
                            name = "Georgin",
                            surname="Hazel",
                            age="29"
                        }
                    });

                    
                    context.Employees.AddRange(new List<Employee>() {

                        new Employee()
                        {
                            id = Guid.NewGuid(),
                            name="Sizwe",
                            surname="Spelling"
                        },
                        new Employee()
                        {
                            id = Guid.NewGuid(),
                            name="George",
                            surname="Danglin"
                        },
                        new Employee()
                        {
                            id = Guid.NewGuid(),
                            name="Hulk",
                            surname="Thorn"
                        },
                        new Employee()
                        {
                            id = Guid.NewGuid(),
                            name="Bruce",
                            surname="Banner"
                        },
                        new Employee()
                        {
                            id = Guid.NewGuid(),
                            name="Max",
                            surname="Maxine"
                        }
                    });

                

                    context.SaveChanges();
                }
            }
        }
    }
}
