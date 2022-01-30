using blazorpractice.Contexts;
using Microsoft.AspNetCore.Components;
using blazorpractice.Models;
using Microsoft.EntityFrameworkCore;
using blazorpractice.Shared;

namespace blazorpractice.Pages;

public partial class Index : ComponentBase
{
    private readonly DatabaseContext _context = new DatabaseContext();

    private ModalView modalView { get; set; }
    private IEnumerable<Company> _companies;

    protected override void OnInitialized()
    {
        _companies = _context.Companies
            .Include(c => c.OwnershipForm)
            .Include(c => c.TargetPurpose)
            .Include(c => c.EconomicSector)
            .ToList();

        base.OnInitialized();
    }

    private void RemoveCompany(Company company)
    {
        _context.Companies.Remove(company);
        _context.SaveChanges();
        _companies = _companies.Where(x => x.Id != company.Id);
        StateHasChanged();
    }
}