using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;

namespace WebApplication3.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication3Context(
            serviceProvider.GetRequiredService<
            DbContextOptions<WebApplication3Context>>()))
            {
                //Look for any .
                if (context.Coach.Any() || context.Player.Any() || context.Team.Any() || context.Contract.Any())
                    {
                        return; // DB has been seeded
                    }

                context.Team.AddRange(
                new Team { /*Id = 1, */Name = "FC Barcelona", StadiumName = "Camp Nou", City = "Barcelona", NumberTitles = 26, CoachId = 1 }
                );

                context.SaveChanges();
                context.Coach.AddRange(
             new Coach { /*Id = 1, */FirstName = "Quique", LastName = "Setien", NumberOfTitles = 0, Country = "Spain", BirthDate = DateTime.Parse("1958-9-27"), TeamId = 1 },
             new Coach { /*Id = 2, */FirstName = "Pep", LastName = "Guardiola", NumberOfTitles = 3, Country = "Spain", BirthDate = DateTime.Parse("1971-1-18") },
             new Coach { /*Id = 3, */FirstName = "Luis", LastName = "Enrique", NumberOfTitles = 2, Country = "Spain", BirthDate = DateTime.Parse("1970-5-8") }
             ) ;
                context.SaveChanges();

                context.Player.AddRange(
                new Player { /*Id = 1, */JerseyNumber= 10, FirstName = "Lionel", LastName = "Messi", Weight = 72, Height = 170, Position = "RW", PrefferedLeg = "Left", Goals = 700, Country = "Spain", BirthDate = DateTime.Parse("1987-6-24"),ContractId=8 },
                new Player { /*Id = 2, */JerseyNumber = 1, FirstName = "Ter", LastName = "Stegen", Weight = 85, Height = 187, Position = "GK", PrefferedLeg = "Right", Goals = 0, Country = "Germany",  BirthDate = DateTime.Parse("1992-4-30"), ContractId = 7 },
                new Player { /*Id = 3, */JerseyNumber = 9, FirstName = "Luis", LastName = "Suarez", Weight = 86, Height = 182, Position = "CF", PrefferedLeg = "Right", Goals = 475, Country = "Uruguay",  BirthDate = DateTime.Parse("1987-1-24") ,ContractId=6},
                new Player { /*Id = 4, */JerseyNumber = 3, FirstName = "Gerard", LastName = "Pique", Weight = 85, Height = 194, Position = "CB", PrefferedLeg = "Right", Goals = 30, Country = "Spain",  BirthDate = DateTime.Parse("1987-2-2"),ContractId = 5  },
                new Player { /*Id = 5, */JerseyNumber = 5, FirstName = "Sergio", LastName = "Busquets", Weight = 86, Height = 189, Position = "CDM", PrefferedLeg = "Right", Goals = 14, Country = "Spain", BirthDate = DateTime.Parse("1988-7-16"), ContractId = 4 },
                new Player { /*Id = 6, */JerseyNumber = 17, FirstName = "Antoine", LastName = "Griezmann", Weight = 73, Height = 176, Position = "LW", PrefferedLeg = "Left", Goals = 200, Country = "France",  BirthDate = DateTime.Parse("1991-3-21"), ContractId = 3 },
                new Player { /*Id = 7, */JerseyNumber = 18, FirstName = "Jordi", LastName = "Alba", Weight = 68, Height = 170, Position = "LB", PrefferedLeg = "Right", Goals = 27, Country = "Spain", BirthDate = DateTime.Parse("1989-3-21"), ContractId = 2 },
                new Player { /*Id = 8, */JerseyNumber = 21, FirstName = "Frenki", LastName = "De Jong", Weight = 74, Height = 180, Position = "CM", PrefferedLeg = "Right", Goals = 15, Country = "Netherlands",  BirthDate = DateTime.Parse("1997-5-12"), ContractId = 1 }
                );
                context.SaveChanges();

                
               
                context.Contract.AddRange(
                new Contract { /*Id = 1, */PlayerId = 1, TeamId = 1, Salary = 27000000, StartingDate = DateTime.Parse("2017-11-25"), FinishDate = DateTime.Parse("2021-6-30") },
                new Contract { /*Id = 2, */PlayerId = 2, TeamId = 1, Salary = 5000000, StartingDate = DateTime.Parse("2017-5-29"), FinishDate = DateTime.Parse("2022-6-30") },
                new Contract { /*Id = 3, */PlayerId = 3, TeamId = 1, Salary = 15000000, StartingDate = DateTime.Parse("2016-12-16"), FinishDate = DateTime.Parse("2021-6-30") },
                new Contract { /*Id = 4, */PlayerId = 4, TeamId = 1, Salary = 12000000, StartingDate = DateTime.Parse("2018-1-18"), FinishDate = DateTime.Parse("2022-6-30") },
                new Contract { /*Id = 5, */PlayerId = 5, TeamId = 1, Salary = 15000000, StartingDate = DateTime.Parse("2018-9-27"), FinishDate = DateTime.Parse("2023-6-30") },
                new Contract { /*Id = 6, */PlayerId = 6, TeamId = 1, Salary = 17000000, StartingDate = DateTime.Parse("2019-7-14"), FinishDate = DateTime.Parse("2024-6-30") },
                new Contract { /*Id = 7, */PlayerId = 7, TeamId = 1, Salary = 3000000, StartingDate = DateTime.Parse("2019-2-28"), FinishDate = DateTime.Parse("2024-6-30") },
                new Contract { /*Id = 8, */PlayerId = 8, TeamId = 1, Salary = 16000000, StartingDate = DateTime.Parse("2019-7-1"), FinishDate = DateTime.Parse("2024-6-30") }

                );
                context.SaveChanges();


                }
            }
        }
    }