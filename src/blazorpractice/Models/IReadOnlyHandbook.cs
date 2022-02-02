namespace blazorpractice.Models;

/// <summary>
/// Базовый интерфейс справочников только для чтения
/// </summary>
public interface IReadOnlyHandbook
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
}