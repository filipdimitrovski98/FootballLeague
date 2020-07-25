using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class WebApplication3Context : DbContext
    {
        public WebApplication3Context (DbContextOptions<WebApplication3Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication3.Models.Coach> Coach { get; set; }

        public DbSet<WebApplication3.Models.Contract> Contract { get; set; }

        public DbSet<WebApplication3.Models.Team> Team { get; set; }

        public DbSet<WebApplication3.Models.Player> Player { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contract>()
            .HasOne<Player>(p => p.Player)
            .WithOne(pa => pa.Contract)
            .HasForeignKey<Contract>(p=>p.PlayerId);

            builder.Entity<Contract>()
            .HasOne<Team>(p => p.Team)
            .WithMany(p => p.Players)
            .HasForeignKey(p => p.TeamId);

            builder.Entity<Coach>()
            .HasOne<Team>(p => p.Team)
            .WithOne(p => p.Coach)
            .HasForeignKey<Coach>(p => p.TeamId);

            builder.Entity<Team>()
            .HasOne<Coach>(p => p.Coach)
            .WithOne(p => p.Team)
            .HasForeignKey<Coach>(p => p.TeamId);

            builder.Entity<Player>()
            .HasOne<Image>(p => p.Image)
            .WithOne(p => p.Player)
            .HasForeignKey<Player>(p => p.ImageId);

            builder.Entity<Image>()
          .HasOne<Player>(p => p.Player)
          .WithOne(p => p.Image)
          .HasForeignKey<Image>(p => p.PlayerId);


        }
        }
    }
