public class Usuario
{
    public Guid Id { get; set; } = Guid.NewGuid();  // Para identificar cada usuário de maneira única
    public string Nome { get; set; }  // Nome de usuário
    public string Senha { get; set; }  // Senha do usuário
}
