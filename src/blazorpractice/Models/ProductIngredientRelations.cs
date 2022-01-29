namespace blazorpractice.Models;

/// <summary>
/// Связь продукт/ингредиент
/// </summary>
public class ProductIngredientRelations : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/> 
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Идентификатор ингредиента
    /// </summary>
    public int IngredientId { get; set; }

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