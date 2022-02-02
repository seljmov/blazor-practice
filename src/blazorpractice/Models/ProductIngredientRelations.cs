using blazorpractice.Contexts;

namespace blazorpractice.Models;

/// <summary>
/// Связь продукт/ингредиент
/// </summary>
public class ProductIngredientRelations : IHandbookBase
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Идентификатор ингредиента
    /// </summary>
    public int IngredientId { get; set; }

    /// <inheritdoc cref="IHandbookBase.Create"/> 
    public void Create()
    {
        var context = new DatabaseContext();
        context.ProductIngredientRelations.Add(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Edit"/> 
    public void Edit()
    {
        var context = new DatabaseContext();
        context.ProductIngredientRelations.Update(this);
        context.SaveChanges();
    }

    /// <inheritdoc cref="IHandbookBase.Remove"/> 
    public void Remove()
    {
        var context = new DatabaseContext();
        context.ProductIngredientRelations.Remove(this);
        context.SaveChanges();
    }
}