using blazorpractice.Contexts;
using blazorpractice.Models;

namespace blazorpractice.Components;

public partial class ProductAdd
{
    private readonly DatabaseContext _context = new();

    private string Name { get; set; }
    private string Description { get; set; }
    private IList<Product> SelectedIngredients { get; set; }
    private IList<Product> Ingredients { get; set; }

    private bool EndCreated { get; set; } = false;
    private bool SuccessCreated { get; set; } = false;

    protected override void OnParametersSet()
    {
        Ingredients = _context.Products.ToList();
    }

    private void CreateProduct()
    {
        EndCreated = true;
        try
        {
            var product = new Product 
            {
                Name = Name,
                Description = Description,
            };

            product.Create();
            var last = _context.Products.ToList().Last();
            if (SelectedIngredients != null && SelectedIngredients.Any())
            {
                foreach (var ingredient in SelectedIngredients)
                {
                    var relation = new ProductIngredientRelations { ProductId = last.Id, IngredientId = ingredient.Id };
                    relation.Create();
                }
                
                _context.SaveChanges();
            }
            SuccessCreated = true;
            return;
        }
        catch (Exception)
        {
        }

        SuccessCreated = false;
    }

    private async Task<IEnumerable<Product>> SearchIngredient(string pattern)
    {
        return await Task.FromResult(Ingredients.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }
}