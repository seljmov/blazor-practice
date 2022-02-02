namespace blazorpractice.Models;

/// <summary>
/// Целевое назначение
/// </summary>
public class TargetPurpose : IHandbookBase, INameable
{
    /// <inheritdoc cref="IReadOnlyHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="INameable.Name"/> 
    public string Name { get; set; }


    /// <inheritdoc cref="IHandbookBase.Create"/> 
    public void Create()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IHandbookBase.Edit"/> 
    public void Edit()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IHandbookBase.Remove"/> 
    public void Remove()
    {
        throw new NotImplementedException();
    }
}