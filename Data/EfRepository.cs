using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Project1.Data
{
    public class EfRepository : IIssueRepository
    {
        private ApplicationDbContext context;

        public EfRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        /*
         * ISSUE REPOSITORY
         */
        public async Task<IReadOnlyList<Issue>> ListAllIssuesAsync()
        {
            return await context.Set<Issue>().ToListAsync();
        }

        public async Task<Issue> GetIssueByIdAsync(int id)
        {
            return await context.Set<Issue>().FindAsync(id);
        }

        public async Task AddIssueAsync(Issue issue)
        {
            await context.Set<Issue>().AddAsync(issue);
            await context.SaveChangesAsync();
        }

        public async Task UpdateIssueAsync(int id ,Issue issue)
        {
            if (id != issue.Id)
            {
                return ;
            }
            context.Entry(issue).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteIssueAsync(int id)
        {
            var issue = await context.Set<Issue>().FindAsync(id);
            if (issue == null)
            {
                return ;
            }
            context.Set<Issue>().Remove(issue);
            await context.SaveChangesAsync();
        }

        
        /*
         * SPRINT REPOSITORY
         
        public async Task<IReadOnlyList<Sprint>> ListAllSprintsAsync()
        {
            return await context.Set<Sprint>().ToListAsync();
        }

        public async Task<Sprint> GetSprintByIdAsync(int id)
        {
            return await context.Set<Sprint>().FindAsync(id);
        }*/
    }
}
