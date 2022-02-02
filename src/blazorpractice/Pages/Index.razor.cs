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
    private IList<Company> companies;

    protected override void OnParametersSet()
    {
        companies = _context.Companies
            .Include(c => c.OwnershipForm)
            .Include(c => c.TargetPurpose)
            .Include(c => c.EconomicSector)
            .ToList();

        companies = companies.Reverse().ToList();
    }

    private void RemoveCompany(Company company)
    {
        company.Remove();
        _context.SaveChanges();
        companies.Remove(company);
        StateHasChanged();
    }
}