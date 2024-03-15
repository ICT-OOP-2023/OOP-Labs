using OOP_ICT.enums;
using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class RoyalFlushHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var listCards = cards.ToList();
        var groupedCards = listCards.GroupBy(card => card.Suit);
        var sortedCards = listCards.OrderBy(card => card.Rank).ToList();
        if (sortedCards[0].Rank == CardRank.Ten && sortedCards[1].Rank == CardRank.Jack &&
            sortedCards[2].Rank == CardRank.Queen && sortedCards[3].Rank == CardRank.King &&
            sortedCards[4].Rank == CardRank.Ace && groupedCards.Any(grouping => grouping.Count() == 5))
        {
            return PokerCombinations.RoyalFlush;
        }
        
        return PokerCombinations.Null;
    }
}