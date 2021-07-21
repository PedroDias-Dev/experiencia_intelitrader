using IntelitraderAPI.Domains;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelitraderAPI.Context
{
    public class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<UsersContext>());
            }
        }

        public static void SeedData(UsersContext context)
        {
            System.Console.WriteLine("Aplicando Migrations...");

            //context.Database.Migrate();

            if(!context.Users.Any())
            {
                System.Console.WriteLine("Adicionando itens...");

                context.Users.AddRange(
                    new User() { firstName = "Pedro", age = 19, surName = "Dias" },
                    new User() { firstName = "Pedro", age = 19, surName = "Dias" },
                    new User() { firstName = "Pedro", age = 19, surName = "Dias" }
                );


                context.SaveChanges();
            }
        }
    }
}
