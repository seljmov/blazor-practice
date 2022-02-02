using Microsoft.EntityFrameworkCore;
using blazorpractice.Models;

namespace blazorpractice.Contexts;

/// <summary>
/// Контекст базы данных
/// </summary>
public class DatabaseContext : DbContext
{
    private readonly string _databasePath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=blazorpracticedb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_databasePath);
    }

    /// <summary>
    /// Словарь предприятий
    /// </summary>
    public DbSet<Company> Companies { get; set; }

    /// <summary>
    /// Словарь связей предприятие/местоположение
    /// </summary>
    public DbSet<CompanyLocationRelation> CompanyLocationRelations { get; set; }

    /// <summary>
    /// Словарь связей предприятие/владелец
    /// </summary>
    public DbSet<CompanyOwnerRelation> CompanyOwnerRelations { get; set; }

    /// <summary>
    /// Словарь связей предприятие/продукт
    /// </summary>
    public DbSet<CompanyProductRelation> CompanyProductRelations { get; set; }

    /// <summary>
    /// Словарь связей предприятие/партнер
    /// </summary>
    public DbSet<CompanyPartnerRelation> CompanyPartnerRelations { get; set; }

    /// <summary>
    /// Словарь связей предприятие/конкурент
    /// </summary>
    public DbSet<CompanyRivalRelation> CompanyRivalRelations { get; set; }

    /// <summary>
    /// СЛоварь отраслей экономики
    /// </summary>
    public DbSet<EconomicSector> EconomicSectors { get; set; }

    /// <summary>
    /// Словарь местоположений
    /// </summary>
    public DbSet<Location> Locations { get; set; }

    /// <summary>
    /// Словарь владельцев
    /// </summary>
    public DbSet<Owner> Owners { get; set; }

    /// <summary>
    /// Словарь форм собственности
    /// </summary>
    public DbSet<OwnershipForm> OwnershipForms { get; set; }

    /// <summary>
    /// Словарь продуктов предприятий
    /// </summary>
    public DbSet<Product> Products { get; set; }

    /// <summary>
    /// Словарь связей продукт/ингредиент
    /// </summary>
    public DbSet<ProductIngredientRelations> ProductIngredientRelations { get; set; }

    /// <summary>
    /// Словарь целевых направлений
    /// </summary>
    public DbSet<TargetPurpose> TargetPurposes { get; set; }
}