using System;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) 
    : base(options) 
    {
        
    }

    public DbSet<Task> Tasks {get; set;}


}
