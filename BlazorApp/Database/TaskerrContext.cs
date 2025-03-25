using Microsoft.AspNetCore.Identity;
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
            PasswordHasher<Usuario> _passwordHasher = new PasswordHasher<Usuario>();

            var usuarioAdmin = new Usuario
            {
                Nome = "admin",
                Senha = "" // Defina a senha do usuário admin
            };

            string hashedPassword = _passwordHasher.HashPassword(usuarioAdmin, "Admin@ICAD!");

            usuarioAdmin.Senha = hashedPassword;

            context.Usuarios.Add(usuarioAdmin);
            context.SaveChanges();  // Salva no banco de dados
        }
    }
}
