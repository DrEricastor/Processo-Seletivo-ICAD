using Microsoft.EntityFrameworkCore;

public class TaskerrContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    public TaskerrContext(DbContextOptions<TaskerrContext> options) : base(options) { }

    // Configurações adicionais, se necessário
}

