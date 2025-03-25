using Microsoft.EntityFrameworkCore;

public class TaskerrContext : DbContext
{
    public TaskerrContext(DbContextOptions<TaskerrContext> options) : base(options) { }

    public DbSet<TodoItemCompleto> TodoItems { get; set; }  // Tabela de tarefas
    public DbSet<Usuario> Usuarios { get; set; }  // Tabela de usuários

    // Método para inicializar o banco de dados com dados padrão
    public static void Initialize(IServiceProvider serviceProvider, TaskerrContext context)
    {
        // Verifica se o banco de dados foi criado
        context.Database.EnsureCreated();

        // Verifica se o usuário admin já existe, caso contrário, cria
        if (!context.Usuarios.Any())
        {
            var usuarioAdmin = new Usuario
            {
                Nome = "admin",
                Senha = "Admin@ICAD!" // Defina a senha do usuário admin
            };

            context.Usuarios.Add(usuarioAdmin);
            context.SaveChanges();  // Salva no banco de dados
        }
    }
}
