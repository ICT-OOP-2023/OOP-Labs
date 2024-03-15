using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class StraightFlushHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var listCards = cards.ToList();
        var groupedCards = listCards.GroupBy(card => card.Suit);
        var sortedCards = listCards.OrderBy(card => card.Rank).ToList();
        for (var i = 0; i < sortedCards.Count - 1; i++)
        {
            if (int.Abs(sortedCards[i].Rank - sortedCards[i + 1].Rank) != 1)
            {
                return PokerCombinations.Null;
            }
        }

        return groupedCards.Any(grouping => grouping.Count() == 5) ? PokerCombinations.StraightFlush
                                                                        : PokerCombinations.Null;
    }
}