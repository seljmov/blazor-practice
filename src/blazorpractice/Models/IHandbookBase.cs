namespace blazorpractice.Models;

/// <summary>
/// Базовый интерфейс редактируемых справочников
/// </summary>
public interface IHandbookBase : IReadOnlyHandbook
{
    /// <summary>
    /// Добавить в справочник
    /// </summary>
    public void Create();
    
    /// <summary>
    /// Отредактировать в справочнике
    /// </summary>
    public void Edit();
    
    /// <summary>
    /// Удалить из справочника
    /// </summary>
    public void Remove();
}