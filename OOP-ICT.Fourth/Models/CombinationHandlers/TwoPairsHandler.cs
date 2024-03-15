using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class TwoPairsHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var groupedCards = cards.GroupBy(card => card.Rank);
        if (groupedCards.Count(grouping => grouping.Count() == 2) == 2)
        {
            return PokerCombinations.TwoPairs;
        }

        return PokerCombinations.Null;
    }
}