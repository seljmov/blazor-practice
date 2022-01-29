﻿namespace blazorpractice.Models;

/// <summary>
/// Владелец предприятия
/// </summary>
public class Owner : IHandbook
{
    /// <inheritdoc cref="IHandbook.Id"/> 
    public int Id { get; set; }

    /// <inheritdoc cref="IHandbook.Name"/> 
    public string Name { get; set; }

    /// <summary>
    /// Месторождения
    /// </summary>
    public string PlaceBirth { get; set; }
    
    /// <summary>
    /// Дата рождения
    /// </summary>
    public string DateBirth { get; set; }
    
    /// <summary>
    /// Гражданство
    /// </summary>
    public string CitizenShip { get; set; }
    
    /// <summary>
    /// Образование
    /// </summary>
    public string Education { get; set; }
    
    /// <summary>
    /// Комментарий
    /// </summary>
    public string Comment { get; set; }

    /// <inheritdoc cref="IHandbook.Create"/> 
    public void Create()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IHandbook.Edit"/> 
    public void Edit()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc cref="IHandbook.Remove"/> 
    public void Remove()
    {
        throw new NotImplementedException();
    }
}