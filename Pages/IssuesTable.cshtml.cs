using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project1.ViewModel.IssueTable;
using Project1.ViewModel.Shared;
using Project1.Interfaces;

namespace Project1
{
    public class IssuesTableModel : PageModel
    {
        private readonly IIssuesTableViewModelService _issuesTableVMService;
        public IssuesTableModel(IIssuesTableViewModelService issuesTableVMService)
        {
            _issuesTableVMService = issuesTableVMService;
        }

        public IssueTableViewModel IssueTable { get; set; }
        public IssueTableFilter Filter { get; set; } = new IssueTableFilter();
        public int CurrentPage { get; set; } = 1;
        public List<string> PageUris { get; set; }

        public async Task OnGetAsync(IssueTableFilter filter ,int currentPage = 1)
        {
            IssueTable = await _issuesTableVMService.GetIssueTableViewModel(filter, currentPage);
            PageUris = await _issuesTableVMService.GetPaginationUris(filter);
            CurrentPage = currentPage;
        }


    }
}