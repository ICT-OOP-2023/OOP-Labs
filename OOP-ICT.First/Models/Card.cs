using OOP_ICT.enums;

namespace OOP_ICT.Models;

public class Card
{
    public CardSuit Suit { get; }
    public CardRank Rank { get; }

    public Card(CardSuit suit, CardRank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}