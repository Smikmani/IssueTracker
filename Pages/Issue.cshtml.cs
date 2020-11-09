using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project1.Data;
using Project1.Data.Entities;
using Project1.Interfaces;
using Project1.ViewModel.Issues;

namespace Project1
{
    public class IssueModel : PageModel
    {
        private readonly IIssueViewModelService _issueVMService;
        public IssueModel(IIssueViewModelService issueVMService)
        {
            _issueVMService = issueVMService;
        }
        public IssueViewModel issueVM { get; set; }
        public async Task OnGetAsync(int id)
        {
            issueVM = await _issueVMService.GetIssueViewModel(id); 
        }
    }
}