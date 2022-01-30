using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace blazorpractice.Components;

public partial class CompanyDetails
{
    private readonly DatabaseContext _context = new DatabaseContext();

    [Parameter]
    public int Id { get; set; }

    private Company Company { get; set; }
    private IEnumerable<Product> Products { get; set; }
    private IEnumerable<Location> Locations { get; set; }
    private IEnumerable<Owner> Owners { get; set; }
    private IEnumerable<Partner> Partners { get; set; }
    private IEnumerable<Rival> Rivals { get; set; }

    protected override void OnInitialized()
    {
        Company = _context.Companies
            .Include(c => c.OwnershipForm)
            .Include(c => c.TargetPurpose)
            .Include(c => c.EconomicSector)
            .ToList().FirstOrDefault(company => company.Id == Id);

        var companyProducts = _context.CompanyProductRelations
            .Where(relation => relation.CompanyId == Company.Id)
            .Select(relation => relation.Id).ToList();
        Products = _context.Products.Where(product => companyProducts.Contains(product.Id)).ToList();

        var companyOwners = _context.CompanyOwnerRelations
            .Where(relation => relation.CompanyId == Company.Id)
            .Select(relation => relation.Id).ToList();
        Owners = _context.Owners.Where(owner => companyOwners.Contains(owner.Id)).ToList();

        Locations = _context.Locations.Where(location => location.CompanyId == Company.Id).ToList();
        Partners = _context.Partners.Where(partner => partner.CompanyId == Company.Id).ToList();
        Rivals = _context.Rivals.Where(rival => rival.CompanyId == Company.Id).ToList();
    }
}