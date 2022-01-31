using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;

namespace blazorpractice.Components;

public partial class LocationEdit
{
    private readonly DatabaseContext _context = new DatabaseContext();

    [Parameter]
    public int Id { get; set; }

    private Location Location { get; set; }

    protected override void OnInitialized()
    {
        Location = _context.Locations.ToList().FirstOrDefault(location => location.Id == Id);
    }
}