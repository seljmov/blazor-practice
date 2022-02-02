using blazorpractice.Contexts;

namespace blazorpractice.Models;

/// <summary>
/// Связь компания/владелеца
/// </summary>
public class CompanyOwnerRelations : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/> 
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор предприятия
    /// </summary>
    public int CompanyId { get; set; }
    
    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    public int OwnerId { get; set; }

    /// <inheritdoc cref="IHandbook.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.CompanyOwnerRelations.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.CompanyOwnerRelations.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.CompanyOwnerRelations.Remove(this);
        context.SaveChanges();
    }
}