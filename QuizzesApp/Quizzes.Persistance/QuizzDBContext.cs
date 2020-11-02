using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;    
using System;
using System.Collections.Generic;
using System.Text;

namespace Quizzes.Persistance
{
    public partial class QuizzDBContext: IdentityDbContext
    {
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


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
