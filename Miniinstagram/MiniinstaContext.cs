using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniinstagram
{
    public class MiniinstaContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Tags> Tags { get; set; }

        

        public MiniinstaContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server = SAHIB-LAPTOP; Database = MiniInstaCodeFirst; Trusted_Connection = True; TrustServerCertificate = True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
             .HasKey(u => u.Id)
             .HasName("PK_Users")
            .IsClustered(false);

            modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();

            modelBuilder.Entity<User>().Property(u => u.Login).HasColumnType("nvarchar(20)");
            modelBuilder.Entity<User>().Property(u => u.Pswd).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<User>().HasCheckConstraint("Login", "Login != ''")
            .HasCheckConstraint("Pswd", "Pswd != ''")
            .HasCheckConstraint("Birthday", "Birthday >= '19900101' AND Birthday <= SYSDATETIME()")
            .Property(u => u.Birthday).IsRequired(false);


            modelBuilder.Entity<Post>().Property(p => p.IdUser).HasColumnName("IdUser");
           modelBuilder.Entity<Post>().HasKey(u => u.Id).IsClustered(false);
            modelBuilder.Entity<Post>().Property(p => p.Date).HasColumnType("datetime2(7)");
            modelBuilder.Entity<Post>().Property(p => p.ImgPath).HasColumnType("nvarchar(255)");
            modelBuilder.Entity<Post>().Property(p => p.Text).IsRequired(false);
            modelBuilder.Entity<Post>().HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.IdUser).OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Posts_User");



            modelBuilder.Entity<Tags>().HasKey(t => t.Id).IsClustered(false);
            modelBuilder.Entity<Tags>().Property(t => t.Tag).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<Tags>().HasCheckConstraint("Tag", "[Tag] != ''");
            







        }


    }

}

