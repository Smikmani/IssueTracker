using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BugTracker.Models;

namespace Project1
{
    public class CreateModel : PageModel
    {
        private readonly IIssueRepository repository;

        public CreateModel(IIssueRepository rep)
        {
            repository = rep;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Issue Issue { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Issue issue)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await repository.AddIssueAsync(issue);

            return RedirectToPage("./Index");
        }
    }
}
