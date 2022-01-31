using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;

namespace blazorpractice.Components;

public partial class OwnerDetails
{
    private readonly DatabaseContext _context = new();

    [Parameter]
    public int Id { get; set; }

    private Owner Owner;
    private IList<Company> Companies { get; set; }

    protected override void OnInitialized()
    {
        Owner = _context.Owners.ToList().FirstOrDefault(x => x.Id == Id);

        var ownersCompanies = _context.CompanyOwnerRelations
            .Where(relation => relation.OwnerId == Id)
            .Select(relation => relation.CompanyId).ToList();
        Companies = _context.Companies.Where(company => ownersCompanies.Contains(company.Id)).ToList();
    }
}