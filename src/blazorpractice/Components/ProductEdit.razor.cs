using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;

namespace blazorpractice.Components;

public partial class ProductEdit
{
    private readonly DatabaseContext _context = new();

    [Parameter]
    public int Id { get; set; }

    private Product Product { get; set; }
    private IList<Product> BeforeEditSelectedIngredients { get; set; }
    private IList<Product> SelectedIngredients { get; set; }
    private IEnumerable<Product> Ingredients { get; set; }

    private bool EndEdit { get; set; } = false;
    private bool SuccessEdit { get; set; } = false;

    protected override void OnParametersSet()
    {
        // Продукты, где текущий продукт является материалом
        var ingredientProducts = _context.ProductIngredientRelations
            .Where(relation => relation.IngredientId == Id)
            .Select(relation => relation.ProductId).ToList();

        Ingredients = _context.Products.Where(product => product.Id != Id && !ingredientProducts.Contains(product.Id)).ToList();
        Product = _context.Products.Where(product => product.Id == Id).FirstOrDefault();

        // Ингредиенты продукта
        var productIngredients = _context.ProductIngredientRelations
            .Where(relation => relation.ProductId == Id)
            .Select(relation => relation.IngredientId).ToList();
        SelectedIngredients = Ingredients.Where(product => productIngredients.Contains(product.Id)).ToList();
        BeforeEditSelectedIngredients = Ingredients.Where(product => productIngredients.Contains(product.Id)).ToList();
    }

    private void EditProduct()
    {
        EndEdit = true;
        try
        {
            Product.Edit();

            var addedIngredients = SelectedIngredients.Where(company => !BeforeEditSelectedIngredients.Contains(company)).ToList();
            var removedIngredients = BeforeEditSelectedIngredients.Where(company => !SelectedIngredients.Contains(company)).ToList();

            foreach (var ingredient in addedIngredients)
            {
                var relation = new ProductIngredientRelations { ProductId = Id, IngredientId = ingredient.Id };
                _context.ProductIngredientRelations.Add(relation);
            }

            foreach (var ingredient in removedIngredients)
            {
                var relation = _context.ProductIngredientRelations.Where(x => x.ProductId == Id && x.IngredientId == ingredient.Id).First();
                _context.ProductIngredientRelations.Remove(relation);
            }

            _context.SaveChanges();

            SuccessEdit = true;
            return;
        }
        catch (Exception e)
        {

        }

        SuccessEdit = false;
    }

    private async Task<IEnumerable<Product>> SearchIngredient(string pattern)
    {
        return await Task.FromResult(Ingredients.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }
}