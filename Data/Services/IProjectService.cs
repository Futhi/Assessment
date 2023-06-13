using Projects.Models;

namespace Projects.Data.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();
        Task<Project> GetById(Guid id);
        Task Update(Guid id, Project newProject);
        Task Delete(Guid id);
        Task Create(Project project);
    }
}
