using OOP_ICT.Fourth.enums;
using OOP_ICT.Fourth.Models.CombinationHandlers;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Abstraction;

public interface ICombinationHandler
{
    PokerCombinations Handle(List<Card> cards);
}