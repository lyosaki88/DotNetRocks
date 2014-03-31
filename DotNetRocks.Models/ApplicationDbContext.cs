using DotNetRocks.Models.GameModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetRocks.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("Local", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // 游戏的DbSet
        public DbSet<Character> Characters { get; set; }
        public DbSet<Package> Packages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .HasKey(x => x.CharacterId)
                .HasRequired(x => x.Package)
                .WithRequiredDependent(x => x.Character);

            base.OnModelCreating(modelBuilder);
        }
    }
}
