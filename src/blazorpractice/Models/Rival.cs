namespace blazorpractice.Models;

/// <summary>
/// Конкурент
/// </summary>
public class Rival : IHandbook
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