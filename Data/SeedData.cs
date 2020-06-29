using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Project1.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            String Length30 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla placerat nisl vel erat commodo, sit amet maximus libero dignissim. Cras consequat enim sed purus euismod tincidunt. Sed consequat luctus lorem.";
            String Length50 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis ac maximus dolor. Curabitur eget volutpat ipsum. Aenean porttitor pretium neque vel pretium. Nullam blandit libero augue, ut rhoncus diam fringilla sed. Donec placerat quam erat, in porttitor dolor rhoncus vitae. Suspendisse vulputate dui at finibus ultrices. Etiam blandit erat in.";
            String Length100 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed tempus eget odio non varius. Donec suscipit augue odio, at condimentum turpis aliquam nec. Donec mattis urna velit, nec dapibus ipsum ultrices id. Proin nec congue lectus, eu suscipit lacus. Proin scelerisque tincidunt magna, id placerat ex vehicula sit amet.Praesent velit quam, tristique ut magna non, egestas imperdiet felis. Proin in ultrices mi. Nulla semper neque ac lectus laoreet interdum.Aliquam et malesuada urna. Fusce maximus ante non mauris dictum facilisis quis at mauris. Fusce non nulla accumsan nunc pellentesque laoreet ultrices eu ipsum. Integer quis accumsan dui, eget scelerisque";
            String Length200 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec dapibus dignissim massa, maximus aliquam nisl viverra ac. Quisque rhoncus lacus vel enim scelerisque, sit amet faucibus nibh pharetra. Fusce convallis, enim in fringilla placerat, lorem augue ultrices nulla, a mattis arcu magna non risus. Duis eget leo malesuada, posuere ex id, volutpat massa. Proin dapibus non risus in interdum. Fusce id mi mauris. In felis tellus, tempor sed dictum sed, lobortis ac risus. Pellentesque fringilla vulputate dolor semper tempus. Vivamus leo justo, lobortis vitae sapien et, accumsan ultricies libero. Proin ultricies ante et purus faucibus efficitur. Fusce placerat gravida est vitae auctor.";
            String Length400 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Donec dapibus dignissim massa, maximus aliquam nisl viverra ac. Quisque rhoncus lacus vel enim scelerisque, sit amet faucibus nibh pharetra. Fusce convallis, enim in fringilla placerat, lorem augue ultrices nulla, a mattis arcu magna non risus. Duis eget leo malesuada, posuere ex id, volutpat massa.Proin dapibus non risus in interdum.Fusce id mi mauris. In felis tellus, tempor sed dictum sed, lobortis ac risus. Pellentesque fringilla vulputate dolor semper tempus. Vivamus leo justo, lobortis vitae sapien et, accumsan ultricies libero. Proin ultricies ante et purus faucibus efficitur.Fusce placerat gravida est vitae auctor. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec dapibus dignissim massa, maximus aliquam nisl viverra ac. Quisque rhoncus lacus vel enim scelerisque, sit amet faucibus nibh pharetra. Fusce convallis, enim in fringilla placerat, lorem augue ultrices nulla, a mattis arcu magna non risus. Duis eget leo malesuada, posuere ex id, volutpat massa. Proin dapibus non risus in interdum. Fusce id mi mauris. In felis tellus, tempor sed dictum sed, lobortis ac risus. Pellentesque fringilla vulputate dolor semper tempus. Vivamus leo justo, lobortis vitae sapien et, accumsan ultricies libero. Proin ultricies ante et purus faucibus efficitur. Fusce placerat gravida est vitae auctor.";

            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Issues.Any())
            {

                context.Projects.AddRange(
                    new Project { Name = "Issue Tracker Project",Description = Length100, LeadId = 1},
                    new Project { Name = "Test Project", Description = Length30, LeadId = 2 }
                );

                context.Teams.AddRange(
                    new Team { Name = "Image Processing", ProjectId = 1 },
                    new Team { Name = "Design", ProjectId = 1 },
                    new Team { Name = "Data Science", ProjectId = 2 },
                    new Team { Name = "Help Desk", ProjectId = 2 }
                );

                context.Types.AddRange(
                    new IssueType { Type = "Bug",Color = "#00ccff" },
                    new IssueType { Type = "Task",Color = "#00cc66" },
                    new IssueType { Type = "Help",Color = "#cc99ff" },
                    new IssueType { Type = "UI",Color = "#ff6699", ProjectId = 2 },
                    new IssueType { Type = "Design", Color = "#660066", ProjectId = 2 },
                    new IssueType { Type = "Customer Support", Color = "#ff9900", ProjectId = 2 },
                    new IssueType { Type = "Backend", Color = "#999966", ProjectId = 2 }
                );

                context.Status.AddRange(
                    new IssueStatus { Status = "To Do", Color = "#00ccff" },
                    new IssueStatus { Status = "Done", Color = "#00cc66" },
                    new IssueStatus { Status = "Urgent", Color = "#cc99ff" },
                    new IssueStatus { Status = "Waiting for Contact", Color = "#ff6699", ProjectId = 1 },
                    new IssueStatus { Status = "Stuck", Color = "#ff0000", ProjectId = 1 },
                    new IssueStatus { Status = "Waiting for Review", Color = "#ff9900", ProjectId = 1 },
                    new IssueStatus { Status = "Waiting for UI", Color = "#999966", ProjectId = 2 },
                    new IssueStatus { Status = "Stuck", Color = "#ff0000", ProjectId = 2 },
                    new IssueStatus { Status = "Waiting for Backend", Color = "#6699ff", ProjectId = 2 }
                );

                context.Issues.AddRange(
                    new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 1, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Codebase is infested",                          Description = Length100,TypeId = 3, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Undefined Variable 2",                          Description = Length50, TypeId = 1, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "New logo design",                               Description = Length50, TypeId = 2, StatusId = 4, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Make navigation responsive",                    Description = Length50, TypeId = 2, StatusId = 5, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Refactor UI using Responsive Design",           Description = Length100,TypeId = 2, StatusId = 6, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Add Logging service using Dependency inhection",Description = Length50, TypeId = 3, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Cache all TYPE and STATUS types",               Description = Length50, TypeId = 1, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 1, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Codebase is infested",                          Description = Length100,TypeId = 3, StatusId = 4, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Undefined Variable 2",                          Description = Length50, TypeId = 1, StatusId = 5, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "New logo design",                               Description = Length50, TypeId = 2, StatusId = 6, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Make navigation responsive",                    Description = Length50, TypeId = 2, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Refactor UI using Responsive Design",           Description = Length100,TypeId = 2, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Add Logging service using Dependency inhection",Description = Length50, TypeId = 3, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Cache all TYPE and STATUS types",               Description = Length50, TypeId = 1, StatusId = 4, UserId = 1, TeamId = 1, ProjectId = 1, CreationDate = DateTime.Now.Date },

                    new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 7, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "New logo design",                               Description = Length50, TypeId = 5, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Make navigation responsive",                    Description = Length50, TypeId = 4, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Undefined Variable 2",                          Description = Length50, TypeId = 4, StatusId = 7, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Add Logging service using Dependency inhection",Description = Length50, TypeId = 7, StatusId = 8, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Refactor UI using Responsive Design",           Description = Length100,TypeId = 4, StatusId = 9, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Codebase is infested",                          Description = Length100,TypeId = 5, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Cache all TYPE and STATUS types",               Description = Length50, TypeId = 7, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Undefined Variable 1",                          Description = Length200,TypeId = 7, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "New logo design",                               Description = Length50, TypeId = 5, StatusId = 7, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Make navigation responsive",                    Description = Length50, TypeId = 4, StatusId = 8, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Undefined Variable 2",                          Description = Length50, TypeId = 4, StatusId = 9, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Add Logging service using Dependency inhection",Description = Length50, TypeId = 7, StatusId = 1, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Refactor UI using Responsive Design",           Description = Length100,TypeId = 4, StatusId = 2, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Codebase is infested",                          Description = Length100,TypeId = 5, StatusId = 3, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date },
                    new Issue { Name = "Cache all TYPE and STATUS types",               Description = Length50, TypeId = 7, StatusId = 7, UserId = 1, TeamId = 1, ProjectId = 2, CreationDate = DateTime.Now.Date }
                );
                
                context.SaveChanges();

            }
        }
    }
}
