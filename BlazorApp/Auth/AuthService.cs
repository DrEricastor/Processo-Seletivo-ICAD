using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // Para hashing de senhas

public static class Auth {
    static public bool isAuthd = false;
    static public Usuario curUser;
}
public class AuthService
{
    private readonly TaskerrContext _context;
    private readonly PasswordHasher<Usuario> _passwordHasher;

    public AuthService(TaskerrContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<Usuario>(); // Inicializa o serviço de hash de senha
    }

    // Método de login
    public async Task<Usuario> Login(string nome, string senha)
    {
        Console.WriteLine("My debug output.");

        // Verifica se existe um usuário com o nome fornecido
        var usuario = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Nome == nome);

        if (usuario == null)
        {
            return null; // Usuário não encontrado
        }

        // Verifica se a senha informada corresponde à senha armazenada (usando hash)
        var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, senha);

        if (result == PasswordVerificationResult.Failed)
        {
            return null; // Senha incorreta
        }

        return usuario; // Retorna o usuário se a senha estiver correta
    }

    // Método para criar um novo usuário
    public async Task<Usuario> Register(string nome, string senha)
    {
        // Verifica se já existe um usuário com o mesmo nome
        var existingUser = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Nome == nome);

        if (existingUser != null)
        {
            return null; // Usuário já existe
        }

        // Cria um novo usuário
        var usuario = new Usuario { Nome = nome };

        // Criptografa a senha antes de salvar no banco de dados
        usuario.Senha = _passwordHasher.HashPassword(usuario, senha);

        // Adiciona o novo usuário no banco de dados
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario; // Retorna o novo usuário criado
    }
}
