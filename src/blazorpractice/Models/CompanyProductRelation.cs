using blazorpractice.Contexts;

namespace blazorpractice.Models;

/// <summary>
/// Связь предприятие/продукт
/// </summary>
public class CompanyProductRelation : IHandbookBase
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор предприятия
    /// </summary>
    public int CompanyId { get; set; }

    /// <summary>
    /// Идентификатор производимого продукта
    /// </summary>
    public int ProductId { get; set; }

    /// <inheritdoc cref="IHandbookBase.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.CompanyProductRelations.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.CompanyProductRelations.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.CompanyProductRelations.Remove(this);
        context.SaveChanges();
    }
}