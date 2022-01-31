using blazorpractice.Contexts;
using blazorpractice.Models;
using blazorpractice.Shared;

namespace blazorpractice.Components;

public partial class Owners
{
    private readonly DatabaseContext _context = new();

    private ModalView ModalView { get; set; }
    private IEnumerable<Owner> owners;

    protected override void OnInitialized()
    {
        owners = _context.Owners.ToList();

        base.OnInitialized();
    }

    private void RemoveOwner(Owner owner)
    {
        _context.Owners.Remove(owner);
        _context.SaveChanges();
        owners = owners.Where(x => x.Id != owner.Id);
        StateHasChanged();
    }
}