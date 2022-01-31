using blazorpractice.Contexts;
using blazorpractice.Models;
using blazorpractice.Shared;

namespace blazorpractice.Components;

public partial class Products
{
    private readonly DatabaseContext _context = new();

    private ModalView ModalView { get; set; }
    private IEnumerable<Product> products;

    protected override void OnInitialized()
    {
        products = _context.Products.ToList();

        base.OnInitialized();
    }

    private void RemoveProduct(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
        products = products.Where(x => x.Id != product.Id);
        StateHasChanged();
    }
}