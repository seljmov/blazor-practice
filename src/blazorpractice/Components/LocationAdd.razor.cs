using blazorpractice.Models;

namespace blazorpractice.Components;

public partial class LocationAdd
{
    private string Name { get; set; }
    private string Address { get; set; }
    private string Comment { get; set; }

    private bool EndCreated { get; set; } = false;
    private bool SuccessCreated { get; set; } = false;

    private void CreateLocation()
    {
        EndCreated = true;
        try
        {
            var location = new Location 
            {
                Name = Name,
                Address = Address,
                Comment = Comment,
            };
            location.Create();

            SuccessCreated = true;
            return;
        }
        catch (Exception)
        {

        }

        SuccessCreated = false;
    }
}