
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quizzes.API.Infrastructure.Auth.Model;

namespace Quizzes.Persistance
{
    public partial class QuizzDBContext : IdentityDbContext<AppUserModel, IdentityRole<int>, int>
    {
        public virtual DbSet<AppUserModel> AppUserModel { get; set; }
        public QuizzDBContext()
        {   

        }

        public QuizzDBContext(DbContextOptions<QuizzDBContext> options)
            : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUserModel>(entity => {
                entity.HasKey(e => e.User_Id);
            });

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
