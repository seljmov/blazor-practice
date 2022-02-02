using blazorpractice.Contexts;
using Microsoft.AspNetCore.Components;
using blazorpractice.Models;
using Microsoft.EntityFrameworkCore;
using blazorpractice.Shared;

namespace blazorpractice.Pages;

public partial class Index : ComponentBase
{
    private readonly DatabaseContext _context = new();

    private ModalView ModalView { get; set; }
    private IEnumerable<Company> _companies;

    protected override void OnParametersSet()
    {
        _companies = _context.Companies
            .Include(c => c.OwnershipForm)
            .Include(c => c.TargetPurpose)
            .Include(c => c.EconomicSector)
            .ToList();
        _companies = _companies.Reverse();
    }

    private void RemoveCompany(Company company)
    {
        company.Remove();
        _context.SaveChanges();
        _companies = _companies.Where(x => x.Id != company.Id);
        StateHasChanged();
    }
}