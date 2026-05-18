using Microsoft.EntityFrameworkCore;
using Todo_Managment_System.Entities;

namespace Todo_Managment_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
