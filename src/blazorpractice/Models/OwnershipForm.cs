namespace blazorpractice.Models;

/// <summary>
/// Форма собственности
/// </summary>
public class OwnershipForm : IReadOnlyHandbook, INameable
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="INameable.Name"/> 
    public string Name { get; set; }
}