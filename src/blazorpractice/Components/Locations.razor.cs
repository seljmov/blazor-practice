using blazorpractice.Contexts;
using blazorpractice.Models;
using blazorpractice.Shared;

namespace blazorpractice.Components;

public partial class Locations
{
    private readonly DatabaseContext _context = new DatabaseContext();

    private ModalView modalView { get; set; }
    private IEnumerable<Location> locations;

    protected override void OnInitialized()
    {
        locations = _context.Locations.ToList();

        base.OnInitialized();
    }

    private void RemoveLocation(Location location)
    {
        _context.Locations.Remove(location);
        _context.SaveChanges();
        locations = locations.Where(x => x.Id != location.Id);
        StateHasChanged();
    }
}