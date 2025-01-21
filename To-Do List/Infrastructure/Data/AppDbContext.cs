using Microsoft.EntityFrameworkCore;
using To_Do_List.Domain.Entities;

namespace To_Do_List.Infrastructure.Data {
    public class AppDbContext : DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "First Task", Status = Domain.Entities.TaskStatus.Pending, CreatedAt = new DateTime(2024, 1, 21, 12, 0, 0) }
            );
        }
    }
}
