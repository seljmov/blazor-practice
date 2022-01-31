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
    private IList<Product> SelectedProducts { get; set; }
    private IEnumerable<Product> Products { get; set; }

    protected override void OnInitialized()
    {
        Products = _context.Products.ToList();
        Product = Products.FirstOrDefault(product => product.Id == Id);
    }

    private async Task<IEnumerable<Product>> SearchProduct(string pattern)
    {
        return await Task.FromResult(Products.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }
}