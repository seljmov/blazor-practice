namespace blazorpractice.Models;

/// <summary>
/// Промышленное предприятие
/// </summary>
public class Company : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/>
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

    /// <inheritdoc cref="IHandbook.Create"/>
    public void Create()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IHandbook.Edit"/>
    public void Edit()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IHandbook.Remove"/>
    public void Remove()
    {
        throw new NotImplementedException();
    }
}