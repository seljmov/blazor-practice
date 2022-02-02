using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;

namespace blazorpractice.Components;

public partial class OwnerEdit
{
    private readonly DatabaseContext _context = new();

    [Parameter]
    public int Id { get; set; }

    private Owner Owner;

    private IList<Company> BeforeEditSelectedCompanies { get; set; }
    private IList<Company> SelectedCompanies { get; set; }
    private IList<Company> Companies { get; set; }

    private bool EndEdit { get; set; } = false;
    private bool SuccessEdit { get; set; } = false;

    protected override void OnParametersSet()
    {
        Owner = _context.Owners.ToList().FirstOrDefault(x => x.Id == Id);

        var ownersCompanies = _context.CompanyOwnerRelations
            .Where(relation => relation.OwnerId == Id)
            .Select(relation => relation.CompanyId).ToList();
        SelectedCompanies = _context.Companies.Where(company => ownersCompanies.Contains(company.Id)).ToList();
        BeforeEditSelectedCompanies = _context.Companies.Where(company => ownersCompanies.Contains(company.Id)).ToList();

        Companies = _context.Companies.ToList();
    }

    private void EditOwner()
    {
        EndEdit = true;
        try
        {
            Owner.Edit();
            var addedCompanies = SelectedCompanies.Where(company => !BeforeEditSelectedCompanies.Contains(company)).ToList();
            var removedCompanies = BeforeEditSelectedCompanies.Where(company => !SelectedCompanies.Contains(company)).ToList();

            foreach (var company in addedCompanies)
            {
                var relation = new CompanyOwnerRelation { CompanyId = company.Id, OwnerId = Owner.Id };
                relation.Create();
            }

            foreach (var company in removedCompanies)
            {
                var relation = _context.CompanyOwnerRelations.Where(x => x.CompanyId == company.Id && Owner.Id == Owner.Id).First();
                relation.Remove();
            }

            _context.SaveChanges();
            SuccessEdit = true;
            return;
        }
        catch (Exception)
        {
        }

        SuccessEdit = false;
    }

    private async Task<IEnumerable<Company>> SearchCompany(string pattern)
    {
        return await Task.FromResult(Companies.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }
}