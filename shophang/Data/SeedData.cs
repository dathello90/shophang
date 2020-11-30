using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Serilog;
using shophang.Helpers;
using shophang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shophang.Data
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<User, Role>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 6;
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddErrorDescriber<CustomIdentityErrorDescriber>();
        }
        private static void SeedRoles(RoleManager<Role> _roleManager)
        {
            if (!_roleManager.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name="Administrator"},
                    
                };

                foreach (var role in roles)
                {
                    var result = _roleManager.CreateAsync(role).Wait(-1);
                    if (result) Log.Debug("Role " + role.Name + " - " + role.Name + " created");
                }
            }
        }
        private static void SeedUser(UserManager<User> _userManager, ApplicationDbContext _dataContext)
        {
            if (!_userManager.Users.Any())
            {
                var dataJson = System.IO.File.ReadAllText("Areas/Identity/Data/user.json");
                var users = JsonConvert.DeserializeObject<List<User>>(dataJson);

                foreach (var user in users)
                {
                    
                    _userManager.CreateAsync(user, "123456").Wait();
                    _userManager.AddToRoleAsync(user, "Administrator").Wait();
                    Log.Debug("User " + user.UserName +  " created");
                }
            }
        }
    }
}
