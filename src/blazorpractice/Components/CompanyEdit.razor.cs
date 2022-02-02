using blazorpractice.Contexts;
using blazorpractice.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace blazorpractice.Components;

public partial class CompanyEdit
{
    private readonly DatabaseContext _context = new();

    [Parameter]
    public int Id { get; set; }

    private Company Company { get; set; }

    private OwnershipForm BeforeSelectedOwnershipForm { get; set; }
    private TargetPurpose BeforeSelectedTargetPurpose { get; set; }
    private EconomicSector BeforeSelectedEconomicSector { get; set; }
    private IList<Location> BeforeSelectedLocations { get; set; }
    private IList<Product> BeforeSelectedProducts { get; set; }
    private IList<Owner> BeforeSelectedOwners { get; set; }
    private IList<Company> BeforeSelectedPartners { get; set; }
    private IList<Company> BeforeSelectedRivals { get; set; }

    private OwnershipForm SelectedOwnershipForm { get; set; }
    private TargetPurpose SelectedTargetPurpose { get; set; }
    private EconomicSector SelectedEconomicSector { get; set; }
    private IList<Location> SelectedLocations { get; set; }
    private IList<Product> SelectedProducts { get; set; }
    private IList<Owner> SelectedOwners { get; set; }
    private IList<Company> SelectedPartners { get; set; }
    private IList<Company> SelectedRivals { get; set; }

    private IEnumerable<OwnershipForm> OwnershipForms { get; set; }
    private IEnumerable<TargetPurpose> TargetPurposes { get; set; }
    private IEnumerable<EconomicSector> EconomicSectors { get; set; }
    private IEnumerable<Location> Locations { get; set; }
    private IEnumerable<Product> Products { get; set; }
    private IEnumerable<Owner> Owners { get; set; }
    private IEnumerable<Company> Partners { get; set; }
    private IEnumerable<Company> Rivals { get; set; }

    private bool EndEdit { get; set; } = false;
    private bool SuccessEdit { get; set; } = false;

    protected override void OnParametersSet()
    {
        Company = _context.Companies
            .Include(c => c.OwnershipForm)
            .Include(c => c.TargetPurpose)
            .Include(c => c.EconomicSector)
            .ToList()
            .FirstOrDefault(company => company.Id == Id);

        SelectedOwnershipForm = Company.OwnershipForm;
        SelectedTargetPurpose = Company.TargetPurpose;
        SelectedEconomicSector = Company.EconomicSector;

        var companyProducts = _context.CompanyProductRelations
            .Where(relation => relation.CompanyId == Company.Id)
            .Select(relation => relation.ProductId).ToList();
        SelectedProducts = _context.Products.Where(product => companyProducts.Contains(product.Id)).ToList();

        var companyOwners = _context.CompanyOwnerRelations
            .Where(relation => relation.CompanyId == Company.Id)
            .Select(relation => relation.OwnerId).ToList();
        SelectedOwners = _context.Owners.Where(owner => companyOwners.Contains(owner.Id)).ToList();

        var companyLocations = _context.CompanyLocationRelations
            .Where(relation => relation.CompanyId == Company.Id)
            .Select(relation => relation.LocationId).ToList();
        SelectedLocations = _context.Locations.Where(location => companyLocations.Contains(location.Id)).ToList();

        // Предприятия-партнеры
        var companyPartners = _context.CompanyPartnerRelations
           .Where(relation => relation.CompanyId == Company.Id)
           .Select(relation => relation.CompanyPartnerId).ToList();
        // Предприятие, где мы партнеры
        var partnersCompanies = _context.CompanyPartnerRelations
           .Where(relation => relation.CompanyPartnerId == Company.Id)
           .Select(relation => relation.CompanyId).ToList();
        SelectedPartners = _context.Companies.Where(company => companyPartners.Contains(company.Id) || partnersCompanies.Contains(company.Id)).Distinct().ToList();

        // Предприятия-конкуренты
        var companyRivals = _context.CompanyRivalRelations
           .Where(relation => relation.CompanyId == Company.Id)
           .Select(relation => relation.CompanyRivalId).ToList();
        // Предприятия, где мы конкуренты
        var rivalsCompany = _context.CompanyRivalRelations
           .Where(relation => relation.CompanyRivalId == Company.Id)
           .Select(relation => relation.CompanyId).ToList();
        SelectedRivals = _context.Companies.Where(company => companyRivals.Contains(company.Id) || rivalsCompany.Contains(company.Id)).Distinct().ToList();

        BeforeSelectedOwnershipForm = Company.OwnershipForm;
        BeforeSelectedTargetPurpose = Company.TargetPurpose;
        BeforeSelectedEconomicSector = Company.EconomicSector;
        BeforeSelectedOwners = _context.Owners.Where(owner => companyOwners.Contains(owner.Id)).ToList();
        BeforeSelectedProducts = _context.Products.Where(product => companyProducts.Contains(product.Id)).ToList();
        BeforeSelectedLocations = _context.Locations.Where(location => companyLocations.Contains(location.Id)).ToList();
        BeforeSelectedPartners = _context.Companies.Where(company => companyPartners.Contains(company.Id) || partnersCompanies.Contains(company.Id)).Distinct().ToList();
        BeforeSelectedRivals = _context.Companies.Where(company => companyRivals.Contains(company.Id) || rivalsCompany.Contains(company.Id)).Distinct().ToList();

        OwnershipForms = _context.OwnershipForms.ToList();
        TargetPurposes = _context.TargetPurposes.ToList();
        EconomicSectors = _context.EconomicSectors.ToList();
        Locations = _context.Locations.ToList();
        Products = _context.Products.ToList();
        Owners = _context.Owners.ToList();
        Partners = _context.Companies.ToList();
        Rivals = _context.Companies.ToList();
    }

    private void EditCompany()
    {
        EndEdit = true;
        try
        {
            Company.Edit();

            var addedLocations = SelectedLocations.Where(x => !BeforeSelectedLocations.Contains(x)).ToList();
            var removedLocations = BeforeSelectedLocations.Where(x => !SelectedLocations.Contains(x)).ToList();

            foreach (var item in addedLocations)
            {
                var relation = new CompanyLocationRelation { CompanyId = Company.Id, LocationId = item.Id };
                relation.Create();
            }

            foreach (var item in removedLocations)
            {
                var relation = _context.CompanyLocationRelations.Where(x => x.CompanyId == Company.Id && x.LocationId == item.Id).First();
                relation.Remove();
            }

            var addedOwners = SelectedOwners.Where(x => !BeforeSelectedOwners.Contains(x)).ToList();
            var removedOwners = BeforeSelectedOwners.Where(x => !SelectedOwners.Contains(x)).ToList();

            foreach (var item in addedOwners)
            {
                var relation = new CompanyOwnerRelation { CompanyId = Company.Id, OwnerId = item.Id };
                relation.Create();
            }

            foreach (var item in removedOwners)
            {
                var relation = _context.CompanyOwnerRelations.Where(x => x.CompanyId == Company.Id && x.OwnerId == item.Id).First();
                relation.Remove();
            }

            var addedProducts = SelectedProducts.Where(x => !BeforeSelectedProducts.Contains(x)).ToList();
            var removedProducts = BeforeSelectedProducts.Where(x => !SelectedProducts.Contains(x)).ToList();

            foreach (var item in addedProducts)
            {
                var relation = new CompanyProductRelation { CompanyId = Company.Id, ProductId = item.Id };
                relation.Create();
            }

            foreach (var item in removedProducts)
            {
                var relation = _context.CompanyProductRelations.Where(x => x.CompanyId == Company.Id && x.ProductId == item.Id).First();
                relation.Remove();
            }

            var addedPartners = SelectedPartners.Where(x => !BeforeSelectedPartners.Contains(x)).ToList();
            var removedPartners = BeforeSelectedPartners.Where(x => !SelectedPartners.Contains(x)).ToList();

            foreach (var item in addedPartners)
            {
                var relation = new CompanyPartnerRelation { CompanyId = Company.Id, CompanyPartnerId = item.Id };
                relation.Create();
            }

            foreach (var item in removedPartners)
            {
                var relation = _context.CompanyPartnerRelations.Where(x => x.CompanyId == Company.Id && x.CompanyPartnerId == item.Id).First();
                relation.Remove();
            }

            var addedRivals = SelectedRivals.Where(x => !BeforeSelectedRivals.Contains(x)).ToList();
            var removedRivals = BeforeSelectedRivals.Where(x => !SelectedRivals.Contains(x)).ToList();

            foreach (var item in addedRivals)
            {
                var relation = new CompanyRivalRelation { CompanyId = Company.Id, CompanyRivalId = item.Id };
                relation.Create();
            }

            foreach (var item in removedRivals)
            {
                var relation = _context.CompanyRivalRelations.Where(x => x.CompanyId == Company.Id && x.CompanyRivalId == item.Id).First();
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

    #region Validation

    private (bool IsHaveEmptyHandbook, string ErrorMessage) CanAddCompanyVerify()
    {
        var names = EmptyHandbooksNames();
        string errorMessage = null;

        if (names == null || !names.Any())
            return (false, errorMessage);

        errorMessage = "Причина: ";

        if (names.Count == 1)
            errorMessage += "пуст справочник ";
        else
            errorMessage += "пусты справочники ";

        for (int i = 0; i < names.Count - 1; i++)
        {
            errorMessage += $"«{names[i]}», ";
        }

        errorMessage += $"«{names.Last()}».";

        return (true, errorMessage);
    }

    private List<string> EmptyHandbooksNames()
    {
        var names = new List<string>();

        if (OwnershipForms == null || !OwnershipForms.Any())
            names.Add("Форма собственности");

        if (TargetPurposes == null || !TargetPurposes.Any())
            names.Add("Целевое направление");

        if (EconomicSectors == null || !EconomicSectors.Any())
            names.Add("Отрасль экономики");

        //if (Locations == null || !Locations.Any())
        //    names.Add("Местоположения");

        //if (Products == null || !Products.Any())
        //    names.Add("Продукты предприятий");

        //if (Owners == null || !Owners.Any())
        //    names.Add("Владельцы");

        //if (Partners == null || !Partners.Any())
        //    names.Add("Партнеры");

        //if (Rivals == null || !Rivals.Any())
        //    names.Add("Конкуренты");

        return names;
    }

    #endregion

    #region Search

    private async Task<IEnumerable<OwnershipForm>> SearchOwnershipForm(string pattern)
    {
        return await Task.FromResult(OwnershipForms.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }

    private async Task<IEnumerable<TargetPurpose>> SearchTargetPurpose(string pattern)
    {
        return await Task.FromResult(TargetPurposes.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }

    private async Task<IEnumerable<EconomicSector>> SearchEconomicSector(string pattern)
    {
        return await Task.FromResult(EconomicSectors.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }

    private async Task<IEnumerable<Location>> SearchLocation(string pattern)
    {
        return await Task.FromResult(Locations.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }

    private async Task<IEnumerable<Product>> SearchProduct(string pattern)
    {
        return await Task.FromResult(Products.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }

    private async Task<IEnumerable<Owner>> SearchOwner(string pattern)
    {
        return await Task.FromResult(Owners.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }

    private async Task<IEnumerable<Company>> SearchPartner(string pattern)
    {
        return await Task.FromResult(Partners.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }

    private async Task<IEnumerable<Company>> SearchRival(string pattern)
    {
        return await Task.FromResult(Rivals.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }

    #endregion
}