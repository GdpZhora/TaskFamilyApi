using Microsoft.EntityFrameworkCore;

namespace TaskFamilyApi.Models
{
    public class TaskDoContext : DbContext
    {

    public TaskDoContext(DbContextOptions<TaskDoContext> options)
    : base(options)
    {
    }

    public DbSet<TaskDo> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // использование Fluent API
        //   base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TaskDo>().ToTable("TaskDo").Property(c => c.Done).HasColumnType("bit(1)");
    }

}
}
