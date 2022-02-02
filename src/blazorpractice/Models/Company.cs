using blazorpractice.Contexts;
using Microsoft.EntityFrameworkCore;

namespace blazorpractice.Models;

/// <summary>
/// Промышленное предприятие
/// </summary>
public class Company : IHandbookBase, INameable
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="INameable.Name"/>
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор формы собственности
    /// </summary>
    public int OwnershipFormId { get; set; }
    
    /// <summary>
    /// Идентификатор целевого направления
    /// </summary>
    public int TargetPurposeId { get; set; }
    
    /// <summary>
    /// Идентификатор отрасли экономики
    /// </summary>
    public int EconomicSectorId { get; set; }
    
    /// <summary>
    /// Количество сотрудников
    /// </summary>
    public int EmployeesCount { get; set; }

    #region For Display

    /// <summary>
    /// Форма собственности
    /// </summary>
    public OwnershipForm OwnershipForm { get; set; }

    /// <summary>
    /// Целевое направление
    /// </summary>
    public TargetPurpose TargetPurpose { get; set; }

    /// <summary>
    /// Отрасль экономики
    /// </summary>
    public EconomicSector EconomicSector { get; set; }

    #endregion

    /// <inheritdoc cref="IHandbookBase.Create"/>
    public void Create()
    {
        var context = new DatabaseContext();
        context.Companies.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Edit"/>
    public void Edit()
    {
        var context = new DatabaseContext();
        context.Companies.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Remove"/>
    public void Remove()
    {
        var context = new DatabaseContext();
        context.Database.ExecuteSqlInterpolated($"execute DeleteCompany @id = {Id}");
        context.SaveChanges();
    }
}