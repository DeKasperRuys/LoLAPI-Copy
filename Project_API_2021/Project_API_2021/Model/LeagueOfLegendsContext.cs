using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project_API_2021.Model
{
    public class LeagueOfLegendsContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<ChampionItem>()
                .HasKey(ci => new { ci.ChampionID, ci.ItemID });
            modelBuilder.Entity<ChampionItem>().
                HasOne(ci => ci.Champion)
                .WithMany(ci => ci.ChampionItem)
                .HasForeignKey(ci => ci.ChampionID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<ChampionItem>().
                HasOne(ci => ci.Item)
                .WithMany(ci => ci.ChampionItem)
                .HasForeignKey(ci => ci.ItemID)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            */

            /* modelBuilder.Entity<Faction>().HasKey(s => s.ID);
             modelBuilder.Entity<Champion>().HasKey(s => s.ID);
             modelBuilder.Entity<Item>().HasKey(s => s.ID);
             modelBuilder.Entity<ChampionItem>().HasKey(s =>
             new
             {
                 s.ChampionID,
                 s.ItemID
             });
            */

            modelBuilder.Entity<ChampionItem>().HasKey(ci =>
            new
            {
                ci.ChampionID,
                ci.ItemID
            }
            );
            // join veel op veel relatie tabel
            modelBuilder.Entity<ChampionItem>()
                .HasOne<Champion>(c => c.Champion)
                .WithMany(c => c.ChampionItem)
                .HasForeignKey(c => c.ChampionID);

            modelBuilder.Entity<ChampionItem>()
                .HasOne<Item>(i => i.Item)
                .WithMany(i => i.ChampionItem)
                .HasForeignKey(i => i.ItemID);
        
        }

        public LeagueOfLegendsContext(DbContextOptions<LeagueOfLegendsContext> options) : base(options)
        {

        }
        public DbSet<Champion> Champions { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Background> Backgrounds { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<ChampionItem> ChampionItems { get; set; }

        
    }
}
