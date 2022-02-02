namespace blazorpractice.Models;

/// <summary>
/// Базовый интерфейс справочников с именуемыми элементами
/// </summary>
public interface INameable
{
    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }
}