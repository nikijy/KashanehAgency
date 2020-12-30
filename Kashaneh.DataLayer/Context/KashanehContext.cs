using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using Kashaneh.DataLayer.Entities.Blog;
using Kashaneh.DataLayer.Entities.Estate;
using Kashaneh.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Kashaneh.DataLayer.Context
{
  public class KashanehContext : DbContext
    {
        
        public KashanehContext(DbContextOptions<KashanehContext> options) : base(options)
        {

        }
        #region User

        public DbSet<Role> Roles { get; set; } 
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }

        #endregion

        #region Blog

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }

        #endregion

        #region Estate

        public DbSet<City> Cities { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstateStatus> EstateStatuses { get; set; }
        public DbSet<EstateType> EstateTypes { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<Estate>()
                .HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<Blog>()
                .HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<UserMessage>()
                .HasQueryFilter(r => !r.IsDeleted);
            modelBuilder.Entity<BlogComment>()
                .HasQueryFilter(r => !r.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
