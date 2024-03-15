using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class FlushHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var groupedCards = cards.GroupBy(card => card.Suit);
        

        if (groupedCards.Any(grouping => grouping.Count() == 5))
        {
            return PokerCombinations.Flush;
        }

        return PokerCombinations.Null;
    }
}