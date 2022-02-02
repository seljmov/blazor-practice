using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;

namespace blazorpractice.Components;

public partial class LocationDetails
{
    private readonly DatabaseContext _context = new();

    [Parameter]
    public int Id { get; set; }

    private Location Location { get; set; }

    protected override void OnParametersSet()
    {
        Location = _context.Locations.Where(x => x.Id == Id).FirstOrDefault();
    }
}