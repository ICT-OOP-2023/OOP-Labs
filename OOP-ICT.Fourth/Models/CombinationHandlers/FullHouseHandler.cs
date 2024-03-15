using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class FullHouseHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var groupedCards = cards.GroupBy(card => card.Rank).ToList();
        if (groupedCards.Any(grouping => grouping.Count() == 3) &&
            groupedCards.Any(grouping => grouping.Count() == 2))
        {
            return PokerCombinations.FullHouse;
        }

        return PokerCombinations.Null;
    }
}