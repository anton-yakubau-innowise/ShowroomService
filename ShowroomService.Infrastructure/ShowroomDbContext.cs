using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ShowroomService.Domain.Entities;

namespace ShowroomService.Infrastructure.Persistence
{
    public class ShowroomDbContext : DbContext
    {
        public DbSet<Showroom> Showrooms { get; set; }

        public ShowroomDbContext(DbContextOptions<ShowroomDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}