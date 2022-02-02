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
    private IEnumerable<Company> Partners { get; set; }
    private IEnumerable<Company> Rivals { get; set; }

    protected override void OnParametersSet()
    {
        Company = _context.Companies
            .Include(c => c.OwnershipForm)
            .Include(c => c.TargetPurpose)
            .Include(c => c.EconomicSector)
            .ToList().FirstOrDefault(company => company.Id == Id);

        var companyProducts = _context.CompanyProductRelations
            .Where(relation => relation.CompanyId == Company.Id)
            .Select(relation => relation.ProductId).ToList();
        Products = _context.Products.Where(product => companyProducts.Contains(product.Id)).ToList();

        var companyOwners = _context.CompanyOwnerRelations
            .Where(relation => relation.CompanyId == Company.Id)
            .Select(relation => relation.OwnerId).ToList();
        Owners = _context.Owners.Where(owner => companyOwners.Contains(owner.Id)).ToList();

        var companyLocations = _context.CompanyLocationRelations
            .Where(relation => relation.CompanyId == Company.Id)
            .Select(relation => relation.LocationId).ToList();
        Locations = _context.Locations.Where(location => companyLocations.Contains(location.Id)).ToList();

        // Предприятия-партнеры
        var companyPartners = _context.CompanyPartnerRelations
           .Where(relation => relation.CompanyId == Company.Id)
           .Select(relation => relation.CompanyPartnerId).ToList();
        // Предприятие, где мы партнеры
        var partnersCompanies = _context.CompanyPartnerRelations
           .Where(relation => relation.CompanyPartnerId == Company.Id)
           .Select(relation => relation.CompanyId).ToList();
        Partners = _context.Companies.Where(company => companyPartners.Contains(company.Id) || partnersCompanies.Contains(company.Id)).Distinct().ToList();

        // Предприятия-конкуренты
        var companyRivals = _context.CompanyRivalRelations
           .Where(relation => relation.CompanyId == Company.Id)
           .Select(relation => relation.CompanyRivalId).ToList();
        // Предприятия, где мы конкуренты
        var rivalsCompany = _context.CompanyRivalRelations
           .Where(relation => relation.CompanyRivalId == Company.Id)
           .Select(relation => relation.CompanyId).ToList();
        Rivals = _context.Companies.Where(company => companyRivals.Contains(company.Id) || rivalsCompany.Contains(company.Id)).Distinct().ToList();
    }
}