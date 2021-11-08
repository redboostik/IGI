using IGI_Web_953501_Smolyar.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_Web_953501_Smolyar.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           context.Database.EnsureCreated();
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };

                await roleManager.CreateAsync(roleAdmin);
            }
            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "111111");
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "111111");
                
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }
            

            if (!context.DrinkGroups.Any())
            {
                context.DrinkGroups.AddRange(
                new List<DrinkGroup>
                {
                    new DrinkGroup {GroupId=1, Name="безалкогольные"},
                    new DrinkGroup {GroupId=2, Name="алкогольные"},
                    new DrinkGroup {GroupId=3, Name="горячие"},
                    new DrinkGroup {GroupId=4, Name="холодные"},
                    new DrinkGroup {GroupId=5, Name="газированные"},
                    new DrinkGroup {GroupId=6, Name="негазированные"}
                });
                await context.SaveChangesAsync();

            }
            // проверка наличия объектов
             if (!context.Drinks.Any())
            {
                context.Drinks.AddRange(
                new List<Drink>
                {
                    new Drink { Name="Вода",
                    Description="вода из под крана",
                    Cost =2, GroupId=1, Image="Вода.jpg" },
                    new Drink {  Name="Пиво",
                    Description="Пиво есть пиво что тут рассказывать",
                    Cost =3, GroupId=2, Image="Пиво.jpg" },
                    new Drink {  Name="Кофе",
                    Description="кофе без кофеина и сахара",
                    Cost =3, GroupId=3, Image="Кофе.jpg" },
                    new Drink {  Name="Кофе",
                    Description="кофе без кофеина и сахара, еще и холодный",
                    Cost =5, GroupId=4, Image="Кофе.jpg" },
                    new Drink {  Name="RED COW",
                    Description="RED COW помогает ведущим спортсменам,/nстудентам, представителям экстремальных\nпрофессий, а также во время длительных\nавтомобильных поездок",
                    Cost =3, GroupId=5, Image="RedCow.jpg" },
                    new Drink {  Name="Чай",
                    Description="Индийский чай",
                    Cost =2, GroupId=6, Image="Чай.jpg" }

                });
                await context.SaveChangesAsync();
            }
           
        }
    }
}
