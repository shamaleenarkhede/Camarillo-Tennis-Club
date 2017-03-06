using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Camarillo_Tennis_Club.Models
{
    public class MatchResultContext : DbContext
    {
        public MatchResultContext(): base("CamarilloTennisClub")
        { }

        public DbSet<Score> Scores { get; set; }
        public DbSet<Players> Player { get; set; }
        public DbSet<Matches> Match { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}