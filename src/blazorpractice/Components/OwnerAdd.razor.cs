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
    private IList<Company> Companies { get; set; }

    private bool EndCreated { get; set; } = false;
    private bool SuccessCreated { get; set; } = false;

    protected override void OnParametersSet()
    {
        Companies = _context.Companies.ToList();
    }

    private void CreateOwner()
    {
        EndCreated = true;
        try
        {
            var owner = new Owner
            {
                Name = Name,
                PlaceBirth = PlaceBirth,
                DateBirth = DateBirth,
                CitizenShip = CitizenShip,
                Education = Education,
                Comment = Comment,
            };

            owner.Create();
            var last = _context.Owners.ToList().Last();
            if (SelectedCompanies != null && SelectedCompanies.Any())
            {
                foreach (var company in SelectedCompanies)
                {
                    var relation = new CompanyOwnerRelation { OwnerId = last.Id, CompanyId = company.Id };
                    relation.Create();
                }
            }

            _context.SaveChanges();
            SuccessCreated = true;
            return;
        }
        catch (Exception)
        {
        }

        SuccessCreated = false;
    }

    private async Task<IEnumerable<Company>> SearchCompany(string pattern)
    {
        return await Task.FromResult(Companies.Where(form => form.Name.ToLower().Contains(pattern.ToLower())));
    }
}