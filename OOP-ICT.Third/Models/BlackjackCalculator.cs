using OOP_ICT.Abstractions;
using OOP_ICT.enums;
using OOP_ICT.Models;
using OOP_ICT.Third.Abstractions;

namespace OOP_ICT.Third.models;

public class BlackjackCalculator : IGameCalculator
{
    public uint CardPower(Card card) => card.Rank switch
    {
        CardRank.Two => 2,
        CardRank.Three => 3,
        CardRank.Four => 4,
        CardRank.Five => 5,
        CardRank.Six => 6,
        CardRank.Seven => 7,
        CardRank.Eight => 8,
        CardRank.Nine => 9,
        CardRank.Ten => 10,
        CardRank.Jack => 10,
        CardRank.Queen => 10,
        CardRank.King => 10,
        CardRank.Ace => 11,
        _ => throw new ArgumentOutOfRangeException($"({card} is invalid rank"),
    };
    
    public uint TotalPowerOfCards(Person player)
    {
        uint result = 0;
        var countOfAces = 0;
        
        foreach (var card in player.GetCards())
        {
            result += CardPower(card);
            if (card.Rank == CardRank.Ace)
            {
                countOfAces++;
            }
        }

        while (result > 21 && countOfAces > 0)
        {
            result -= 10;
            countOfAces--;
        }

        return result;
    }
}