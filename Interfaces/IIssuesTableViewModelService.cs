using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project1.ViewModel.IssueTable;
using Project1.ViewModel.Shared;
namespace Project1.Interfaces
{
    public interface IIssuesTableViewModelService
    {
        Task<IssueTableViewModel> GetIssueTableViewModel(IssueTableFilter filter, int currentPage);
        Task<List<string>> GetPaginationUris(IssueTableFilter filter);
        Task<List<SelectItem>> GetTypeSelectItems();
        Task<List<SelectItem>> GetStatusSelectItems();
    }
}
