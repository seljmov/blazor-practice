namespace blazorpractice.Models;

/// <summary>
/// Отрасли экономики
/// </summary>
public class EconomicSector : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/> 
    public string Name { get; set; }

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