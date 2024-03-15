using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class ThreeOfKindHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var groupingCards = cards.GroupBy(card => card.Rank);
        if (groupingCards.Any(grouping => grouping.Count() == 3))
        {
            return PokerCombinations.ThreeOfAKind;
        }

        return PokerCombinations.Null;
    }
}