using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public IssueViewModel IssueVM { get; set; }
        public string JsonIssue { get; set; }
        public async Task OnGetAsync(int id)
        {
            IssueVM = await _issueVMService.GetIssueViewModel(id);

            if (IssueVM.Issue?.Comments != null) IssueVM.Issue.Comments.Reverse();
            if (IssueVM.Issue?.Changes != null)  IssueVM.Issue.Changes.Reverse();
            if (IssueVM.Issue?.Files != null)  IssueVM.Issue.Files.Reverse();
            
            JsonIssue = JsonSerializer.Serialize(IssueVM.Issue);
        }
    }
}