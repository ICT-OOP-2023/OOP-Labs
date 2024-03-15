using OOP_ICT.Abstractions;
using OOP_ICT.Models;

namespace OOP_ICT.Third.Abstractions;

public interface IGameCalculator
{
    uint CardPower(Card card);
    
    uint TotalPowerOfCards(Person player);
}