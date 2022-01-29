namespace blazorpractice.Models;

/// <summary>
/// Интерфейс справочников
/// </summary>
public interface IHandbook
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Наименование
    /// </summary>
    public string Name { get; set; }

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