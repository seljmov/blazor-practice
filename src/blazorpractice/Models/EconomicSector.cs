namespace blazorpractice.Models;

/// <summary>
/// Отрасль экономики
/// </summary>
public class EconomicSector : IReadOnlyHandbook, INameable
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="INameable.Name"/> 
    public string Name { get; set; }
}