using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models.CombinationHandlers;

public class StraightHandler : ICombinationHandler
{
    public PokerCombinations Handle(List<Card> cards)
    {
        var sortedCards = cards.OrderBy(card => card.Rank).ToList();

        for (var i = 0; i < sortedCards.Count - 1; i++)
        {
            if (int.Abs(sortedCards[i].Rank - sortedCards[i + 1].Rank) != 1)
            {
                return PokerCombinations.Null;
            }
        }
        
        return PokerCombinations.Straight;
    }
}