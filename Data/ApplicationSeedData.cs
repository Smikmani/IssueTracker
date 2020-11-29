using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project1.Data.Entities;

namespace Project1.Data
{
    public class ApplicationSeedData
    {

        static string Length30 = "Lorem ipsum dolor sit amet er.";
        static string Length50 = "Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.";
        static string Length100 = "Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.";
        static string Length200 = "Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.";
        //static string Length400 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Donec dapibus dignissim massa, maximus aliquam nisl viverra ac. Quisque rhoncus lacus vel enim scelerisque, sit amet faucibus nibh pharetra. Fusce convallis, enim in fringilla placerat, lorem augue ultrices nulla, a mattis arcu magna non risus. Duis eget leo malesuada, posuere ex id, volutpat massa.Proin dapibus non risus in interdum.Fusce id mi mauris. In felis tellus, tempor sed dictum sed, lobortis ac risus. Pellentesque fringilla vulputate dolor semper tempus. Vivamus leo justo, lobortis vitae sapien et, accumsan ultricies libero. Proin ultricies ante et purus faucibus efficitur.Fusce placerat gravida est vitae auctor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec dapibus dignissim massa, maximus aliquam nisl viverra ac. Quisque rhoncus lacus vel enim scelerisque, sit amet faucibus nibh pharetra. Fusce convallis, enim in fringilla placerat, lorem augue ultrices nulla, a mattis arcu magna non risus. Duis eget leo malesuada, posuere ex id, volutpat massa. Proin dapibus non risus in interdum. Fusce id mi mauris. In felis tellus, tempor sed dictum sed, lobortis ac risus. Pellentesque fringilla vulputate dolor semper tempus. Vivamus leo justo, lobortis vitae sapien et, accumsan ultricies libero. Proin ultricies ante et purus faucibus efficitur. Fusce placerat gravida est vitae auctor.";
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            if(context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
            
            if (!context.Changes.Any())
            {

                if (!await context.Projects.AnyAsync())
                {
                    await context.Projects.AddRangeAsync(GetPreconfiguredProjects());

                    await context.SaveChangesAsync();
                }

                if (!await context.Teams.AnyAsync())
                {
                    await context.Teams.AddRangeAsync(GetPreconfiguredTeams());

                    await context.SaveChangesAsync();
                }

                if (!await context.Types.AnyAsync())
                {
                    await context.Types.AddRangeAsync(GetPreconfiguredTypes());

                    await context.SaveChangesAsync();
                };

                if (!await context.Status.AnyAsync())
                {
                    await context.Status.AddRangeAsync(GetPreconfiguredStatus());

                    await context.SaveChangesAsync();
                };

                if (!await context.Issues.AnyAsync())
                {
                    await context.Issues.AddRangeAsync(GetPreconfiguredIssues());

                    await context.SaveChangesAsync();
                };
                if (!await context.Comments.AnyAsync())
                {
                    await context.Comments.AddRangeAsync(GetPreconfiguredComms());

                    await context.SaveChangesAsync();
                };
                if (!await context.Changes.AnyAsync())
                {
                    await context.Changes.AddRangeAsync(GetPreconfiguredChanges());

                    await context.SaveChangesAsync();
                };

                await context.SaveChangesAsync();
            }
        }
        
        public static IEnumerable<Project> GetPreconfiguredProjects()
        {
            return new List<Project>
            {
                 new Project { Name = "Issue Tracker Project",Description = Length100, LeadId = 1},
                 new Project { Name = "Test Project", Description = Length30, LeadId = 2 }
            };
        }

        static IEnumerable<Team> GetPreconfiguredTeams()
        {
            return new List<Team>
            {
                new Team { Name = "Image Processing", ProjectId = 1 },
                new Team { Name = "Design", ProjectId = 1 },
                new Team { Name = "Data Science", ProjectId = 2 },
                new Team { Name = "Help Desk", ProjectId = 2 }
            };
        }

        static IEnumerable<Entities.Types> GetPreconfiguredTypes()
        {
            return new List<Types>
            {
                new Types { Name = "Bug", Color = "#00ccff" },
                new Types { Name = "Task", Color = "#00cc66" },
                new Types { Name = "Help", Color = "#cc99ff" },
                new Types { Name = "UI", Color = "#ff6699", ProjectId = 2 },
                new Types { Name = "Design", Color = "#660066", ProjectId = 2 },
                new Types { Name = "Customer Support", Color = "#ff9900", ProjectId = 2 },
                new Types { Name = "Backend", Color = "#999966", ProjectId = 2 }
            };
        }

        static IEnumerable<Status> GetPreconfiguredStatus()
        {
            return new List<Status>
            {
                new Status { Name = "To Do", Color = "#00ccff" },
                new Status { Name = "Done", Color = "#00cc66" },
                new Status { Name = "Urgent", Color = "#cc99ff" },
                new Status { Name = "Waiting for Contact", Color = "#ff6699", ProjectId = 1 },
                new Status { Name = "Stuck", Color = "#ff0000", ProjectId = 1 },
                new Status { Name = "Waiting for Review", Color = "#ff9900", ProjectId = 1 },
                new Status { Name = "Waiting for UI", Color = "#999966", ProjectId = 2 },
                new Status { Name = "Stuck", Color = "#ff0000", ProjectId = 2 },
                new Status { Name = "Waiting for Backend", Color = "#6699ff", ProjectId = 2 }
            };
        }
        static IEnumerable<Comment> GetPreconfiguredComms()
        {
            return new List<Comment>
            {
                new Comment { Body = "To Do dfgiudgf dfghFGiugg FGI*jhgijgug GIUGigiugi",               IssueId = 30, UserId = 1, UserName = "User1" },
                new Comment { Body = "Done done did it broski fdoiho ohHoihoho oihoih",                IssueId = 30, UserId = 2, UserName = "User2" },
                new Comment { Body = "Urgent hiuHGooih hoihhOh 0OIhoihoghfuyf IUGHIOiougoiughohohhiougiugiugiugihi iugiug",   IssueId = 30, UserId = 3, UserName = "User3" },
                new Comment { Body = "Waiting for Contact", IssueId = 30, UserId = 4, UserName = "User4" },
                new Comment { Body = "Stuck",               IssueId = 30, UserId = 1, UserName = "User1" },
                new Comment { Body = "Waiting for Review",  IssueId = 30, UserId = 2, UserName = "User2" },
                new Comment { Body = "Waiting for UI",      IssueId = 30, UserId = 1, UserName = "User1" },
                new Comment { Body = "Stuck" ,              IssueId = 30, UserId = 2, UserName = "User2" },
                new Comment { Body = "Waiting for Backend", IssueId = 30, UserId = 2, UserName = "User2" }
            };
        }
        static IEnumerable<Change> GetPreconfiguredChanges()
        {
            return new List<Change>
            {
                new Change {  IssueId=30, Property = "Status", Before ="To Do", After ="Stuck", UserId = 2, UserName="User2"},
                new Change {  IssueId=30, Property = "Type",   Before ="Bug", After ="Task", UserId = 2, UserName="User2"},
                new Change {  IssueId=30, Property = "Description", Before ="Old description. Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.", After ="Lorem ipsum dolor sit amet er.Lorem ipsum dolor sit.", UserId = 2, UserName="User2"},
                new Change {  IssueId=30, Property = "Name", Before ="Make nav bar Responsive", After ="Make navigation responsive", UserId = 2, UserName="User2"},
                new Change {  IssueId=30, Property = "Team", Before ="Back-end Team", After ="Front-End Team", UserId = 2, UserName="User2"},
            };
        }
        static IEnumerable<Issue> GetPreconfiguredIssues()
        {
            return new List<Issue>
            {
                new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 1, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 1, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Codebase is infested",                          Description = Length100,TypeId = 3, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Undefined Variable 2",                          Description = Length50, TypeId = 1, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "New logo design",                               Description = Length50, TypeId = 2, StatusId = 4, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Refactor UI using Responsive Design",           Description = Length100,TypeId = 2, StatusId = 6, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Make navigation responsive",                    Description = Length50, TypeId = 2, StatusId = 5, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Add Logging service using Dependency inhection",Description = Length50, TypeId = 3, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Cache all TYPE and STATUS types",               Description = Length50, TypeId = 1, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 1, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Codebase is infested",                          Description = Length100,TypeId = 3, StatusId = 4, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Undefined Variable 2",                          Description = Length50, TypeId = 1, StatusId = 5, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "New logo design",                               Description = Length50, TypeId = 2, StatusId = 6, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Make navigation responsive",                    Description = Length50, TypeId = 2, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Refactor UI using Responsive Design",           Description = Length100,TypeId = 2, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Add Logging service using Dependency inhection",Description = Length50, TypeId = 3, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Cache all TYPE and STATUS types",               Description = Length50, TypeId = 1, StatusId = 4, UserId = 1, TeamId = 1, ProjectId = 1, DueDate = new DateTime(2022, 5, 6)},
                                                                                                                                                                             
                new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 7, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "New logo design",                               Description = Length50, TypeId = 5, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Make navigation responsive",                    Description = Length50, TypeId = 4, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Undefined Variable 2",                          Description = Length50, TypeId = 4, StatusId = 7, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Add Logging service using Dependency inhection",Description = Length50, TypeId = 7, StatusId = 8, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Refactor UI using Responsive Design",           Description = Length100,TypeId = 4, StatusId = 9, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Codebase is infested",                          Description = Length100,TypeId = 5, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Cache all TYPE and STATUS types",               Description = Length50, TypeId = 7, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 7, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "New logo design",                               Description = Length50, TypeId = 5, StatusId = 7, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Make navigation responsive",                    Description = Length50, TypeId = 4, StatusId = 8, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Undefined Variable 2",                          Description = Length50, TypeId = 4, StatusId = 9, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Add Logging service using Dependency inhection",Description = Length50, TypeId = 7, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Refactor UI using Responsive Design",           Description = Length100,TypeId = 4, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Codebase is infested",                          Description = Length100,TypeId = 5, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)},
                new Issue { Name = "Cache all TYPE and STATUS types",               Description = Length50, TypeId = 7, StatusId = 7, UserId = 1, TeamId = 1, ProjectId = 2, DueDate = new DateTime(2022, 5, 6)}
            };
        }
    }
}
