﻿using Microsoft.EntityFrameworkCore;

namespace Ef7JsonColumns.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseSqlServer("server=localhost;database=Ef7JsonColumns;Trusted_Connection=true;Encrypt=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>().OwnsOne(sh => sh.Details, navigationsBuilder =>
            {
                navigationsBuilder.ToJson();
                //navigationsBuilder.ToTable("HeroDetails");
            });
        }

        public DbSet<SuperHero> Heroes { get; set; }
    }
}
