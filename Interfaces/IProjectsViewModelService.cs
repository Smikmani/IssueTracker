using System.Collections.Generic;
using System.Threading.Tasks;
using Project1.ViewModel.Projects;

namespace Project1.Interfaces
{
    public interface IProjectsViewModelService
    {
        Task<IReadOnlyList<ProjectViewModel>> GetProjects();
        Task<int> GetUserId();
    }
}
