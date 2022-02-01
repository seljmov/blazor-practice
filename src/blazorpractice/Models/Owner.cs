using blazorpractice.Contexts;

namespace blazorpractice.Models;

/// <summary>
/// Владелец предприятия
/// </summary>
public class Owner : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/> 
    public string Name { get; set; }

    /// <summary>
    /// Месторождения
    /// </summary>
    public string PlaceBirth { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public string DateBirth { get; set; }
    
    /// <summary>
    /// Гражданство
    /// </summary>
    public string CitizenShip { get; set; }
    
    /// <summary>
    /// Образование
    /// </summary>
    public string Education { get; set; }
    
    /// <summary>
    /// Комментарий
    /// </summary>
    public string Comment { get; set; }

    /// <inheritdoc cref="IHandbook.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.Owners.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.Owners.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbook.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        var ownerCompaniesRelations = context.CompanyOwnerRelations.Where(relation => relation.OwnerId == Id);
        foreach (var relation in ownerCompaniesRelations)
            context.CompanyOwnerRelations.Remove(relation);
        context.Owners.Remove(this);
        context.SaveChanges();
    }
}