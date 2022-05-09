using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebTerritoryAPI.Models;

namespace WebTerritoryAPI.DBContexts
{
    public class TerritoryContext : DbContext
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Street> Streets{ get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Spot> Spots { get; set; }
        public TerritoryContext(DbContextOptions<TerritoryContext> options) : base (options)
        {
            Database.EnsureCreated();
        }
    }
}
