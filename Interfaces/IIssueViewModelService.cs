using Project1.Data.Entities;
using Project1.ViewModel.Issues;
using Project1.ViewModel.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project1.Interfaces
{
    public interface IIssueViewModelService
    {
        Task<IssueViewModel> GetIssueViewModel(int id);
        Task<Issue> GetIssue(int id);
        Task<List<SelectItem>> GetTypesSelectItems();
        Task<List<SelectItem>> GetStatusSelectItems();
        Task<List<SelectItem>> GetTeamsSelectItems();
    }
}
