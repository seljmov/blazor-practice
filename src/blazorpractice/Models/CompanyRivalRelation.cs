using blazorpractice.Contexts;

namespace blazorpractice.Models;

/// <summary>
/// Связь компания/конкурента
/// </summary>
public class CompanyRivalRelation : IHandbook
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
    /// Идентификатор предприятия-конкурента
    /// </summary>
    public int CompanyRivalId { get; set; }

    /// <inheritdoc cref="IHandbook.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.CompanyRivalRelations.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.CompanyRivalRelations.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.CompanyRivalRelations.Remove(this);
        context.SaveChanges();
    }
}