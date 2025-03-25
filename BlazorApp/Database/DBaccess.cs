using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class TarefaService {
    private readonly TaskerrContext _context;
    public TarefaService(TaskerrContext context) {
        _context = context;
    }

    public async Task<List<TodoItemCompleto>> GetTarefasAsync() {
        return await _context.TodoItems.ToListAsync();
    }

    public async Task AddTarefaAsync(TodoItemCompleto tarefa) {
        _context.TodoItems.Add(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task EditTarefaAsync(TodoItemCompleto tarefa) {
        _context.TodoItems.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveTarefaAsync(Guid tarefaId) {
        var tarefa = await _context.TodoItems.FindAsync(tarefaId);
        if (tarefa != null) {
            _context.TodoItems.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<TodoItemCompleto>> GetTarefasByUserAsync(Guid userId)
{
    return await _context.TodoItems
        .Where(t => t.User == userId) // Filtra pelo ID do usuário
        .ToListAsync();
}

}