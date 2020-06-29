using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Project1.Data
{
    public interface IIssueRepository
    {
        Task<IReadOnlyList<Issue>> ListAllIssuesAsync();
        Task<Issue> GetIssueByIdAsync(int id);
        Task AddIssueAsync(Issue issue);
        Task DeleteIssueAsync(int id);
        Task UpdateIssueAsync(int id, Issue issue);
    }
}
