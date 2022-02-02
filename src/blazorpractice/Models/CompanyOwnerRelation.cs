using blazorpractice.Contexts;

namespace blazorpractice.Models;

/// <summary>
/// Связь компания/владелеца
/// </summary>
public class CompanyOwnerRelation : IHandbookBase
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор предприятия
    /// </summary>
    public int CompanyId { get; set; }
    
    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    public int OwnerId { get; set; }

    /// <inheritdoc cref="IHandbookBase.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.CompanyOwnerRelations.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.CompanyOwnerRelations.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.CompanyOwnerRelations.Remove(this);
        context.SaveChanges();
    }
}