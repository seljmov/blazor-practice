using blazorpractice.Contexts;
using Microsoft.EntityFrameworkCore;

namespace blazorpractice.Models;

/// <summary>
/// Продукт предприятия
/// </summary>
public class Product : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/> 
    public string Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }

    /// <inheritdoc cref="IHandbook.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.Products.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.Products.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.Database.ExecuteSqlInterpolated($"execute DeleteProduct @id = {Id}");
        context.SaveChanges();
    }
}