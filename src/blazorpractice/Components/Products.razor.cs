using blazorpractice.Contexts;
using blazorpractice.Models;
using blazorpractice.Shared;

namespace blazorpractice.Components;

public partial class Products
{
    private readonly DatabaseContext _context = new();

    private ModalView ModalView { get; set; }
    private IEnumerable<Product> products;

    protected override void OnParametersSet()
    {
        products = _context.Products.ToList();
        products = products.Reverse();
    }

    private void RemoveProduct(Product product)
    {
        product.Remove();
        products = products.Where(x => x.Id != product.Id);
        StateHasChanged();
    }
}