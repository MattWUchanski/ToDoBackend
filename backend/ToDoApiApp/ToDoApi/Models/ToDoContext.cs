using Microsoft.EntityFrameworkCore;

namespace ToDoApi.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>(entity =>
            {
                entity.HasKey(e => e.TaskId);
                entity.Property(e => e.TaskTitle).IsRequired().HasMaxLength(100);
                entity.Property(e => e.TaskDate).IsRequired();
                entity.Property(e => e.TaskTime).IsRequired();
                entity.Property(e => e.TaskIsComplete).IsRequired();
            });
        }

    }
}

