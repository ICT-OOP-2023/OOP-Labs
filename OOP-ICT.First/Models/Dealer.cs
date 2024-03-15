using OOP_ICT.Abstractions;

namespace OOP_ICT.Models;

public class Dealer : Person
{
    private readonly CardDeck _cardDeck;
    
    public Dealer(CardDeck cardDeck, string name = "Incognito") : base(name)
    {
        _cardDeck = cardDeck;
    }
    
    public void Shuffle()
    {
        if (_cardDeck.Cards.Count == 0)
        {
            throw new ArgumentNullException(nameof(_cardDeck) + "is empty");
        }

        var halfLen = _cardDeck.Cards.Count / 2;
        var firstHalf = _cardDeck.Cards.GetRange(0, halfLen);
        var secondHalf = _cardDeck.Cards.GetRange(halfLen, halfLen);
        _cardDeck.Cards.Clear();
        
        for (var i = 0; i < halfLen; i++)
        {
            _cardDeck.Cards.Add(firstHalf[i]);
            _cardDeck.Cards.Add(secondHalf[i]);
        }
    }

    public Card Dealing()
    {
        if (_cardDeck.Cards.Count == 0) 
        {
            throw new ArgumentNullException(nameof(_cardDeck) + "is empty");
        }
        
        var card = _cardDeck.Cards[0];
        _cardDeck.Cards.Remove(card);
        return card;
    }
}