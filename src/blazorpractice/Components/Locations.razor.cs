using blazorpractice.Contexts;
using blazorpractice.Models;
using blazorpractice.Shared;

namespace blazorpractice.Components;

public partial class Locations
{
    private readonly DatabaseContext _context = new();

    private ModalView ModalView { get; set; }
    private IList<Location> locations;

    protected override void OnParametersSet()
    {
        locations = _context.Locations.ToList();
        locations = locations.Reverse().ToList();
    }

    private void RemoveLocation(Location location)
    {
        location.Remove();
        locations.Remove(location);
        StateHasChanged();
    }
}