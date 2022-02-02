using blazorpractice.Contexts;

namespace blazorpractice.Models;

/// <summary>
/// Связь компания/конкурента
/// </summary>
public class CompanyRivalRelation : IHandbookBase
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор предприятия
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// Идентификатор предприятия-конкурента
    /// </summary>
    public int CompanyRivalId { get; set; }

    /// <inheritdoc cref="IHandbookBase.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.CompanyRivalRelations.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.CompanyRivalRelations.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.CompanyRivalRelations.Remove(this);
        context.SaveChanges();
    }
}