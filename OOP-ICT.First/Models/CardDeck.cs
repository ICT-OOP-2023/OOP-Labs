using OOP_ICT.enums;

namespace OOP_ICT.Models;

public class CardDeck
{
    public List<Card> Cards { get; } = new();

    public CardDeck()
    {
        foreach(var suit in Enum.GetValues<CardSuit>())
        {
            foreach (var rank in Enum.GetValues<CardRank>().Reverse())
            {
                Cards.Add(new Card(suit, rank));
            }
        }
    }
}