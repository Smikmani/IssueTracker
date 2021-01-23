using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project1.Interfaces;
using Project1.ViewModel.Create;
using Project1.Extensions;
using Project1.ViewModel.Shared;

namespace Project1
{
    public class CreateModel : PageModel
    {
        private readonly ICreateViewModelService _createVMService;
        public CreateModel(ICreateViewModelService createVMService) {

            _createVMService = createVMService;
        }


        [BindProperty]
        public CreateViewModel CreateVM { get; set; }

        public async Task OnGetAsync()
        {
            CreateVM = new CreateViewModel();

            CreateVM = await _createVMService.GetCreateViewModel();

            TempData.Set("Type", CreateVM.Types);
            TempData.Set("Status", CreateVM.Status);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CreateVM.Types = TempData.Get<List<SelectItem>>("Type");
            CreateVM.Status = TempData.Get<List<SelectItem>>("Status");

            var isValidType = false;

            if(CreateVM.Types.Exists(t => t.Id==CreateVM.Issue.TypeId))
            {
                isValidType = true;
            }
            

            if(isValidType)
            {
                if (CreateVM.Status.Exists(s => s.Id==CreateVM.Issue.StatusId))
                {
                    await _createVMService.CreateIssue(CreateVM.Issue);
                    return RedirectToPage("./Dashboard");
                }
            }

            TempData.Keep();
            return Page();


            /*
            if (createVM.FormFile == null)
            {
                return RedirectToPage("./Index");
            }

            string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            string containerName = "images";

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            var fileName = $"{createM.Issue.Name.Replace(" ", "-")}" + Path.GetExtension(createM.FormFile.FileName);

            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            //var file = new File (createM.FormFile,"image/jpeg")
            if (createM.FormFile.Length > 0)
            {
                using (Stream stream = createM.FormFile.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }
            }
            if (file.Exists)
            {
                file.Delete();
            }
            using (var fs = file.Create())
            {
                await createM.FormFile.CopyToAsync(fs);
            }*/

        }
    }
}
