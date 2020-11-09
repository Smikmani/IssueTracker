using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Project1.Data;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project1.Data.Entities;
using System.Collections.Generic;
using System.Linq;


namespace Project1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var applicationContext = services.GetRequiredService<ApplicationDbContext>();
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                    await ApplicationSeedData.SeedAsync(applicationContext, userManager, roleManager);
                    var userRoles = new List<string>
                    {
                        "Admin",
                        "Senior",
                        "Staff",
                        "Junior"
                    };

                    var userEmails = new List<string>
                    {
                        "user1email@test.com",
                        "user2email@test.com",
                        "user3email@test.com",
                        "user4email@test.com"
                    };
                    var projects = ApplicationSeedData.GetPreconfiguredProjects().ToList();
                    var user1 = userManager.FindByEmailAsync("user1email@test.com");
                    if (user1.Result == null)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            await roleManager.CreateAsync(new ApplicationRole { Name = userRoles[i] });
                            await userManager.CreateAsync(new ApplicationUser { UserName = $"user{i + 1}", Email = userEmails[i] }, "password");
                            var user = await userManager.FindByEmailAsync(userEmails[i]);
                            await userManager.AddToRoleAsync(user, userRoles[i]);
                            if (i != 2)
                            {
                                await applicationContext.ProjectUsers.AddRangeAsync(new ProjectUsers { User = user, Project = projects[0] }, new ProjectUsers { User = user, Project = projects[1] });
                            }
                            else
                            {
                                await applicationContext.ProjectUsers.AddAsync(new ProjectUsers { User = user, Project = projects[0] });
                            }
                        }
                    }
                        
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
