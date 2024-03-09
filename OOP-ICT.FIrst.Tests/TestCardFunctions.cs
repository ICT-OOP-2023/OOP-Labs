using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.FIrst.Tests;

public class TestCardFunctions
{
    [Fact]
    public void DealingCardsReducesDeckSize()
    {
        var dealer = new Dealer();
        var initialDeckSize = dealer.Deck.GetShuffledDeck().Count;

        var hand = dealer.DealCards(5).ToList();

        Assert.Equal(initialDeckSize - 5, dealer.Deck.GetShuffledDeck().Count);
    }

    [Fact]
    public void DealingCardsReturnsCorrectNumberOfCards()
    {
        Dealer dealer = new Dealer();

        var hand = dealer.DealCards(5);

        Assert.Equal(5, hand.Count);
    }
    
    [Fact]
    public void ShuffledDeckHas52Cards()
    {
        var dealer = new Dealer();

        var shuffledDeck = dealer.Deck.GetShuffledDeck();

        Assert.Equal(52, shuffledDeck.Count);
    }
}
