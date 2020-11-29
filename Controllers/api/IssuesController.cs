using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Blobs;

using Project1.Data;
using Project1.Data.Entities;
using System.IO;

namespace Project1.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IssuesController(ApplicationDbContext context,
                                UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
  
        [HttpPut("{id}/name")]
        public async Task<ActionResult<Change>> PutIssueName(int id, IssueStringProp issueName)
        {

            if (issueName == null)
            {
                return BadRequest();
            }

            var name = issueName.Text;

            if (name.Length > 250 ||
                name.Length == 0)
            {
                return BadRequest();
            }

            var projectId = HttpContext.Session.GetInt32("projectId");
            var issue = await _context.Issues.FirstAsync(i => i.Id == id && i.ProjectId == projectId);

            if (issue == null)
            {
                return BadRequest();
            }
            
            issue.Name = name;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpPut("{id}/desc")]
        public async Task<ActionResult<Change>> PutIssueDesc(int id, IssueStringProp issueDesc)
        {

            if (issueDesc == null)
            {
                return BadRequest();
            }

            var desc = issueDesc.Text;

            if (desc.Length == 0)
            {
                return BadRequest();
            }

            var projectId = HttpContext.Session.GetInt32("projectId");
            var issue = await _context.Issues.FirstAsync(i => i.Id == id && i.ProjectId == projectId);

            if (issue == null)
            {
                return BadRequest();
            }

            var change = new Change { Before = issue.Description, After = desc, IssueId = id , Property = "Description" };
            await PostChange(change);
            
            issue.Description = desc;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return change;
        }

        [HttpPut("{id}/type")]
        public async Task<ActionResult<Change>> PutIssueType(int id, IssueIntProp issueTypeId)
        {
            
            if (issueTypeId == null)
            {
                return BadRequest();
            }

            var typeId = issueTypeId.Id;
            var projectId = HttpContext.Session.GetInt32("projectId");
            var type = await _context.Types.FirstOrDefaultAsync(t => t.Id == typeId && (t.ProjectId == projectId || t.ProjectId == 0));

            if (type == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues.Include(i => i.Type).FirstAsync(i => i.Id == id && i.ProjectId == projectId);

            if(issue == null)
            {
                return BadRequest();
            }

            var change = new Change { Before = issue.Type.Name, After = type.Name, IssueId = id, Property = "Type" };
            await PostChange(change);

            issue.TypeId = typeId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return change;
        }
        
        [HttpPut("{id}/status")]
        public async Task<ActionResult<Change>> PutIssueStatus(int id, IssueIntProp issueStatusId)
        {
           
            if (issueStatusId == null)
            {
                return BadRequest();
            }

            var statusId = issueStatusId.Id;
            var projectId = HttpContext.Session.GetInt32("projectId");
            var status = await _context.Status.FirstOrDefaultAsync(s => s.Id == statusId && (s.ProjectId == projectId || s.ProjectId == 0));

            if (status == null)
            {
                return NotFound();
            }

            var issue = await _context.Issues.Include(i => i.Status).FirstOrDefaultAsync(i => i.Id == id && i.ProjectId == projectId);

            if(issue ==  null)
            {
                return BadRequest();
            }

            var change = new Change { Before = issue.Status.Name, After = status.Name, IssueId = id, Property = "Status" };
            await PostChange(change);

            issue.StatusId = statusId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return change;
        }

        [HttpPut("{id}/date")]
        public async Task<ActionResult<Change>> PutIssueDueDate(int id, IssueDateProp issueName)
        {

            if (issueName == null)
            {
                return BadRequest();
            }

            var date = issueName.Date;

            if(date < DateTime.UtcNow)
            {
                return BadRequest();
            }
            

            var projectId = HttpContext.Session.GetInt32("projectId");
            var issue = await _context.Issues.FirstOrDefaultAsync(i => i.Id == id && i.ProjectId == projectId);

            if (issue == null)
            {
                return BadRequest();
            }

            var change = new Change { Before = issue.DueDate.ToString(), After = date.ToString(), IssueId = id, Property = "Due Date" };
            await PostChange(change);

            issue.DueDate = date;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return change;
        }
       
        
        
        // POST: api/Issues
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        public async Task<ActionResult<Comment>> PostComment(int id,Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            var projectId = HttpContext.Session.GetInt32("projectId");
            var issueExists = await _context.Issues.AnyAsync(i => i.Id == id && i.ProjectId == projectId );

            
            if(!issueExists)
            {
                return BadRequest();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            comment.UserId = user.Id;
            comment.UserName = user.UserName;
            comment.IssueId = id;

            _context.Comments.Add(comment);

            await _context.SaveChangesAsync();
            
            return  comment ;
        }

        

        [HttpDelete("comment/{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("{id}/file"), DisableRequestSizeLimit]
        public async Task<IActionResult> PostFile(int id)
        {
            if (Request.Form.Files.Count==0)
            {
                return BadRequest(new { text = "No file submitted"});
            }

            var file = Request.Form.Files[0];

            if (file.Length == 0)
            {
                return BadRequest();
            }

            var fileName = file.FileName;
            var ext = Path.GetExtension(fileName);
            ext = ext.ToUpperInvariant();

            if(!(ext.Equals(".TXT") || ext.Equals(".PDF")|| ext.Equals(".DOC") || ext.Equals(".DOCX") || ext.Equals(".DOCM") || ext.Equals(".CSV") || ext.Equals(".XLSX") || ext.Equals(".JPG") || ext.Equals(".JPEG") || ext.Equals(".PNG") ))
            {
                return BadRequest(new { text = $"This file type ({ext}) is not supported" });
            }

            try
            {
                string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
                string containerName = "files";

                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                BlobClient blobClient = containerClient.GetBlobClient(fileName);
                var uri = blobClient.Uri.AbsoluteUri;

                using (Stream stream = file.OpenReadStream())
                {
                    var res = await blobClient.UploadAsync(stream, true);
                }

                if (!(await _context.Files.AnyAsync(f => f.Uri==uri)))
                {
                    var fileDetails = new FileDetails { IssueId = id, Uri = uri };

                    await PostFileDetails(fileDetails);

                    return Ok(fileDetails);
                }

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal sserver error: {ex}");
            }
            

            // Process uploaded files
            // Don't rely on or trust the FileName property without validation.
        }

        [HttpDelete("file/{id}")]
        public async Task<ActionResult> DeleteFile(int id)
        {
            var fileDetails = await _context.Files.FindAsync(id);
            if (fileDetails == null)
            {
                return NotFound();
            }

            _context.Files.Remove(fileDetails);
            await _context.SaveChangesAsync();

            try
            {
                string connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
                string containerName = "files";

                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                BlobClient blobClient = containerClient.GetBlobClient(fileDetails.Uri.Substring(fileDetails.Uri.LastIndexOf("/")+1));

                await blobClient.DeleteIfExistsAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal sserver error: {ex}");
            }

        }

        [NonAction]
        private async Task PostChange(Change change)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            change.UserId = user.Id;
            change.UserName = user.UserName;

            _context.Changes.Add(change);

            await _context.SaveChangesAsync();
        }

        private async Task PostFileDetails(FileDetails file)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            file.UserId = user.Id;

            _context.Files.Add(file);

            await _context.SaveChangesAsync();
        }
    }

    public class IssueStringProp
    {
        public string Text { get; set; }
    }
    public class IssueIntProp
    {
        public int Id { get; set; }
    }
    public class IssueDateProp
    {
        public DateTime Date { get; set; }
    }
}
