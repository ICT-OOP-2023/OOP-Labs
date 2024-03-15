using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class OnePairHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var groupedCards = cards.GroupBy(card => card.Rank);
        if (groupedCards.Any(grouping => grouping.Count() == 2))
        {
            return PokerCombinations.OnePair;
        }
        
        return PokerCombinations.Null;
    }
}