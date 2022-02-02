namespace blazorpractice.Models;

/// <summary>
/// Целевое назначение
/// </summary>
public class TargetPurpose : IReadOnlyHandbook, INameable
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="INameable.Name"/> 
    public string Name { get; set; }
}