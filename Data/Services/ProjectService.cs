using Microsoft.EntityFrameworkCore;
using Projects.Models;

namespace Projects.Data.Services
{
    public class ProjectService: IProjectService
    {
        private readonly ProjectsDbContext _context;

        public ProjectService(ProjectsDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            var results = _context.Projects.ToList();
            return results;
        }
        public async Task<Project> GetById(Guid id)
        {
            var projectsDetails = await _context.Projects.FirstOrDefaultAsync(n => n.id == id);
            return projectsDetails;
        }

        public async Task Update(Guid id, Project newData)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(n => n.id == id);

            if (dbProject != null)
            {
                dbProject.name = newData.name;
                dbProject.startDate = newData.startDate;
                dbProject.endDate = newData.endDate;

            }
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var dbProject = await _context.Projects.FirstOrDefaultAsync(n => n.id == id);
            _context.Projects.Remove(dbProject);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Project project)
        {
            var newProject = new Project()
            {
                id = Guid.NewGuid(),
                name = project.name,
                startDate = project.startDate,
                endDate = project.endDate
            };
            await _context.Projects.AddAsync(newProject);
            await _context.SaveChangesAsync();

        }
    }
}
