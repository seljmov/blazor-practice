using blazorpractice.Contexts;
using Microsoft.EntityFrameworkCore;

namespace blazorpractice.Models;

/// <summary>
/// Местоположение
/// </summary>
public class Location : IHandbookBase, INameable
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="INameable.Name"/> 
    public string Name { get; set; }

    /// <summary>
    /// Адрес
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Комментарий
    /// </summary>
    public string Comment { get; set; }

    /// <inheritdoc cref="IHandbookBase.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.Locations.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.Locations.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.Database.ExecuteSqlInterpolated($"execute DeleteLocation @id = {Id}");
        context.SaveChanges();
    }
}