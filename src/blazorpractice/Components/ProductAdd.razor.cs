using blazorpractice.Contexts;
using blazorpractice.Models;

namespace blazorpractice.Components;

public partial class ProductAdd
{
    private readonly DatabaseContext _context = new();

    private string Name { get; set; }
    private string Description { get; set; }
    private IList<Product> SelectedProducts { get; set; }
    private IEnumerable<Product> Products { get; set; }

    protected override void OnInitialized()
    {
        Products = _context.Products.ToList();
    }

    private async Task<IEnumerable<Product>> SearchProduct(string pattern)
    {
        return await Task.FromResult(Products.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }
}