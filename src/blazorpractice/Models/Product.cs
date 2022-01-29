namespace blazorpractice.Models;

/// <summary>
/// Продукт предприятия
/// </summary>
public class Product : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/> 
    public string Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }

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