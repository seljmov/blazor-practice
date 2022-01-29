namespace blazorpractice.Models;

/// <summary>
/// Информация для лога
/// </summary>
public class LogInfo
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id {  get; set; }

    /// <summary>
    /// Информация
    /// </summary>
    public string Info { get; set; }

    /// <summary>
    /// Дата создания лога
    /// </summary>
    public DateTime CreatedDate { get; set; }
}