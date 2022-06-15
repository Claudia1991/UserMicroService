using Microsoft.EntityFrameworkCore;
using System;
using UserMicroService.EntitiesProvider.DomainEntities;

namespace UserMicroService.DataAccess.Context
{
    public class UserMicroServiceContext : DbContext
    {
        public UserMicroServiceContext(DbContextOptions<UserMicroServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(50);
            //modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Juan Perez", Birthdate= DateTime.Now, Active = true },
                                                new User { Id = 2, Name = "Juana Perez", Birthdate = DateTime.Now.AddDays(1), Active = true });
        }
    }
}
