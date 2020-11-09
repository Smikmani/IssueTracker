using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Project1.Data.Entities;
using System.Threading;

namespace Project1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProjectUsers>()
                .HasKey(cs => new { cs.ProjectId, cs.UserId });
            
            modelBuilder.Entity<Issue>()
                .HasIndex(i => i.ProjectId);
            modelBuilder.Entity<Comment>()
                .HasIndex(i => i.IssueId);
            
        }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectUsers> ProjectUsers { get; set; }
        public DbSet<Team> Teams { get; set; }
        // DbSet<Change> Changes { get; set; }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaving();
            return await base.SaveChangesAsync(cancellationToken);
        }
            
        private void BeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                
                if (entry.Entity is BaseEntity trackable)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdateDate = utcNow;
                            break;
                        case EntityState.Added:
                            trackable.CreationDate = utcNow;
                            break;
                    }
                }
            }
        }
        
    }
}
