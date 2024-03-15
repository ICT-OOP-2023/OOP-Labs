using OOP_ICT.enums;
using OOP_ICT.Models;
using Xunit;

namespace OOP_ICT.First.Tests;

public class TestCardFunctions
{
    [Fact]
    public void CardInitializationTest()
    {
        const CardSuit cardSuit = CardSuit.Clubs;
        const CardRank cardRank = CardRank.Ten;

        var card = new Card(cardSuit, cardRank);
        
        Assert.Equal(cardSuit, card.Suit);
        Assert.Equal(cardRank, card.Rank);
    }

    [Fact]
    public void CardDeckInitializationTest()
    {
        var cardDeck = new CardDeck();
        var count = 0;

        foreach (var suit in Enum.GetValues<CardSuit>())
        {
            foreach (var rank in Enum.GetValues<CardRank>().Reverse())
            {
                var card = new Card(suit, rank);
                Assert.Equal(card.Suit, cardDeck.Cards[count].Suit);
                Assert.Equal(card.Rank, cardDeck.Cards[count].Rank);
                count++;
            }
        }
    }

    [Fact]
    public void ShuffleMethodTest()
    {
        var deck = new CardDeck();
        var dealer = new Dealer(deck);
        var newDeck = new CardDeck();
        
        dealer.Shuffle();
        
        Assert.Equal(newDeck.Cards.Count, deck.Cards.Count);
        Assert.NotEqual(newDeck.Cards, deck.Cards);
    }

    [Fact]
    public void ArgumentNullExceptionInShuffleTest()
    {
        CardDeck emptyDeck = new();
        emptyDeck.Cards.Clear();
        var dealer = new Dealer(emptyDeck);
        
        Assert.Throws<ArgumentNullException>(() => dealer.Shuffle());
    }

    [Fact]
    public void DealingMethodTest()
    {
        var deck = new CardDeck();
        var dealer = new Dealer(deck);
        
        Assert.Equal(deck.Cards[0], dealer.Dealing());
    }

    [Fact]
    public void ArgumentNullExceptionInDealingTest()
    {
        CardDeck emptyDeck = new();
        emptyDeck.Cards.Clear();
        var dealer = new Dealer(emptyDeck);
        
        Assert.Throws<ArgumentNullException>(() => dealer.Dealing());
    }
}