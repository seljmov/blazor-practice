using blazorpractice.Contexts;

namespace blazorpractice.Models;

/// <summary>
/// Связь предприятие/партнер
/// </summary>
public class CompanyPartnerRelation : IHandbook
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
    /// Идентификатор предприятия-партнера
    /// </summary>
    public int CompanyPartnerId { get; set; }

    /// <inheritdoc cref="IHandbook.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.CompanyPartnerRelations.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.CompanyPartnerRelations.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.CompanyPartnerRelations.Remove(this);
        context.SaveChanges();
    }
}