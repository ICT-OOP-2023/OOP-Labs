using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class FourOfKindHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var groupedCards = cards.GroupBy(card => card.Rank);
        if (groupedCards.Any(grouping => grouping.Count() == 4))
        {
            return PokerCombinations.FourOfAKind;
        }

        return PokerCombinations.Null;
    }
}