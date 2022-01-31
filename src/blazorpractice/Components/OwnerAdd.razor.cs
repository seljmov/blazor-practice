using blazorpractice.Contexts;
using blazorpractice.Models;

namespace blazorpractice.Components;

public partial class OwnerAdd
{
    private readonly DatabaseContext _context = new();

    private string Name { get; set; }
    public string PlaceBirth { get; set; }
    public string DateBirth { get; set; }
    public string CitizenShip { get; set; }
    public string Education { get; set; }
    public string Comment { get; set; }
    private IList<Company> SelectedCompanies { get; set; }
    private IEnumerable<Company> Companies { get; set; }

    protected override void OnInitialized()
    {
        Companies = _context.Companies.ToList();
    }

    private async Task<IEnumerable<Company>> SearchCompany(string pattern)
    {
        return await Task.FromResult(Companies.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }
}