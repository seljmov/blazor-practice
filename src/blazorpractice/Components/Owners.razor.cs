using blazorpractice.Contexts;
using blazorpractice.Models;
using blazorpractice.Shared;

namespace blazorpractice.Components;

public partial class Owners
{
    private readonly DatabaseContext _context = new();

    private ModalView ModalView { get; set; }
    private IList<Owner> owners;

    protected override void OnParametersSet()
    {
        owners = _context.Owners.ToList();
        owners = owners.Reverse().ToList();
    }

    private void RemoveOwner(Owner owner)
    {
        owner.Remove();
        owners.Remove(owner);
        StateHasChanged();
    }
}