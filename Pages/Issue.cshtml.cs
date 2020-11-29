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
using System.Text.Json;


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
        public string JsonIssue { get; set; }
        public async Task OnGetAsync(int id)
        {
            issueVM = await _issueVMService.GetIssueViewModel(id);


            if(issueVM.Issue?.Comments != null) issueVM.Issue.Comments.Reverse();
            if (issueVM.Issue?.Changes != null)  issueVM.Issue.Changes.Reverse();
            if (issueVM.Issue?.Files != null)  issueVM.Issue.Files.Reverse();
            
            JsonIssue = JsonSerializer.Serialize(issueVM.Issue);
        }
    }
}