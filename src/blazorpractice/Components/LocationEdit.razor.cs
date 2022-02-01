using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;

namespace blazorpractice.Components;

public partial class LocationEdit
{
    private readonly DatabaseContext _context = new();

    [Parameter]
    public int Id { get; set; }

    private Location Location { get; set; }

    private bool EndEdit { get; set; } = false;
    private bool SuccessEdit { get; set; } = false;

    protected override void OnInitialized()
    {
        Location = _context.Locations.ToList().FirstOrDefault(location => location.Id == Id);
    }

    private void EditLocation()
    {
        EndEdit = true;
        try
        {
            Location.Edit();
            SuccessEdit = true;
            return;
        }
        catch (Exception)
        {

        }

        SuccessEdit = false;
    }
}