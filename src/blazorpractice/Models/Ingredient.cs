namespace blazorpractice.Models;

/// <summary>
/// Материал продукта
/// </summary>
public class Ingredient : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/> 
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор продукта, являющего ингредиентом
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Требуемое количество
    /// </summary>
    public int RequiredAmount { get; set; }

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