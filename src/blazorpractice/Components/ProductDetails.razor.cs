using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;

namespace blazorpractice.Components;

public partial class ProductDetails
{
    private readonly DatabaseContext _context = new();

    [Parameter]
    public int Id { get; set; }

    private Product Product;
    private IList<Product> Ingredients { get; set; }

    protected override void OnParametersSet()
    {
        Product = _context.Products.Where(x => x.Id == Id).FirstOrDefault();

        var productIngredients = _context.ProductIngredientRelations
            .Where(relation => relation.ProductId == Id)
            .Select(relation => relation.IngredientId).ToList();
        Ingredients = _context.Products.Where(product => productIngredients.Contains(product.Id)).ToList();
    }
}