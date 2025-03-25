using System.ComponentModel;


// public class TodoItem
// {
//     public string? Title { get; set; }
//     public bool IsDone { get; set; } = false;
// }

public static class Auth {
    static public bool isAuthd = false;
}

public class TodoItemCompleto
{
    public Guid Id {get; private set;}
    public string Title { get; set;} = "";
    public string Description { get; set;} = "";
    public DateTime? DueDate { get; set;}
    public string User { get; set;} = ""; //TODO
    public string Difficulty { get; set;} = "";
    public bool isDone {get; set;} = false;

    public TodoItemCompleto()
    {
        this.Id = Guid.NewGuid();
    }
}

public static class TodoList
{
    private static List<TodoItemCompleto> Tarefas = new List<TodoItemCompleto>{};

    public static List<TodoItemCompleto> Get() {
        return Tarefas;
    }
    
    public static void Add(TodoItemCompleto item) {
        Tarefas.Add(item);
        return;
    }

    public static void Remove(TodoItemCompleto item) {
        Tarefas.Remove(item);
        return;
    }

    
}
