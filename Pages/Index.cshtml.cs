
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project1.ViewModel;
using Project1.Interfaces;
using System.Collections.Generic;
using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Authorization;

namespace Project1
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        
        public IndexModel()
        {
            
        }
        //public List<string> images { get; set; } = new List<string>();
        public async Task  OnGetAsync()
        {
            /*string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            // Create BlobServiceClient from the account URI

            // Get reference to the container
            BlobContainerClient container = blobServiceClient.GetBlobContainerClient("thumbnails74906509-8e8f-48ce-8e15-8ea679bc3e53");

            if (container.Exists())
            {
                foreach (BlobItem blobItem in container.GetBlobs())
                {
                    images.Add(container.Uri + "/" + blobItem.Name);
                }
            }*/
        }

    }
}