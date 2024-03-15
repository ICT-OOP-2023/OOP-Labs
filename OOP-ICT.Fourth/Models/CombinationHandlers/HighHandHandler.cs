using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class HighHandHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        return PokerCombinations.HighHand;
    }
}