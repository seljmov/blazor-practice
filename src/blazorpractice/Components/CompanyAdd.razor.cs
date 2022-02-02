using blazorpractice.Contexts;
using blazorpractice.Models;

namespace blazorpractice.Components;

public partial class CompanyAdd
{
    private readonly DatabaseContext _context = new DatabaseContext();

    private string Name { get; set; }
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

    private bool EndCreated { get; set; } = false;
    private bool SuccessCreated { get; set; } = false;

    protected override void OnParametersSet()
    {
        OwnershipForms = _context.OwnershipForms.ToList();
        TargetPurposes = _context.TargetPurposes.ToList();
        EconomicSectors = _context.EconomicSectors.ToList();
        Locations = _context.Locations.ToList();
        Products = _context.Products.ToList();
        Owners = _context.Owners.ToList();
        Partners = _context.Companies.ToList();
        Rivals = _context.Companies.ToList();
    }

    private void CreateCompany()
    {
        EndCreated = true;
        var company = new Company
        {
            Name = Name,
            OwnershipFormId = SelectedOwnershipForm.Id,
            TargetPurposeId = SelectedTargetPurpose.Id,
            EconomicSectorId = SelectedEconomicSector.Id,
        };

        try
        {
            company.Create();
            var last = _context.Companies.ToList().Last();
            if (SelectedLocations != null && SelectedLocations.Any())
            {
                foreach (var location in SelectedLocations)
                {
                    var relation = new CompanyLocationRelation { CompanyId = last.Id, LocationId = location.Id };
                    relation.Create();
                }
            }

            if (SelectedOwners != null && SelectedOwners.Any())
            {
                foreach (var owner in SelectedOwners)
                {
                    var relation = new CompanyOwnerRelation { CompanyId = last.Id, OwnerId = owner.Id };
                    relation.Create();
                }
            }

            if (SelectedProducts != null && SelectedProducts.Any())
            {
                foreach (var product in SelectedProducts)
                {
                    var relation = new CompanyProductRelation { CompanyId = last.Id, ProductId = product.Id };
                    relation.Create();
                }
            }

            if (SelectedPartners != null && SelectedPartners.Any())
            {
                foreach (var partner in SelectedPartners)
                {
                    var relation = new CompanyPartnerRelation { CompanyId = last.Id, CompanyPartnerId = partner.Id };
                    relation.Create();
                }
            }

            if (SelectedRivals != null && SelectedRivals.Any())
            {
                foreach (var rival in SelectedRivals)
                {
                    var relation = new CompanyRivalRelation { CompanyId = last.Id, CompanyRivalId = rival.Id };
                    relation.Create();
                }
            }

            _context.SaveChanges();
            SuccessCreated = true;
            return;
        }
        catch (Exception)
        {
            company.Remove();
        }

        SuccessCreated = false;
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