namespace Template.Models.Entities;

/// <summary>
/// Abstraction for anything with limited seats that a traveler can reserve.
/// </summary>
public interface IBookable
{
    int Capacity { get; }
    int SeatsLeft { get; }
    bool CanReserve(int seats);
    void Reserve(int seats);
    void Release(int seats);
}
