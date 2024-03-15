using Moq;
using OOP_ICT.enums;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Fourth.Models;
using OOP_ICT.Fourth.Models.Strategies;
using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Fourth.Tests;

public class Tests
{
    [Fact]
    public void StraightHandlerTest()
    {
        var testCards = new List<Card>
        {
            new(CardSuit.Clubs, CardRank.Two),
            new(CardSuit.Diamonds, CardRank.Three),
            new(CardSuit.Hearts, CardRank.Five),
            new(CardSuit.Diamonds, CardRank.Four),
            new(CardSuit.Hearts, CardRank.Six)
        };

        Assert.Equal(PokerCombinations.Straight, PokerHandler.FindCombinations(testCards));
    }
    
    [Fact]
    public void StraightFlushHandlerTest()
    {
        var testCards = new List<Card>
        {
            new(CardSuit.Hearts, CardRank.Five),
            new(CardSuit.Hearts, CardRank.Four),
            new(CardSuit.Hearts, CardRank.Two),
            new(CardSuit.Hearts, CardRank.Three),
            new(CardSuit.Hearts, CardRank.Six)
        };

        Assert.Equal(PokerCombinations.StraightFlush, PokerHandler.FindCombinations(testCards));
    }
    
    [Fact]
    public void TwoPairsHandlerTest()
    {
        var testCards = new List<Card>
        {
            new(CardSuit.Clubs, CardRank.Two),
            new(CardSuit.Diamonds, CardRank.Three),
            new(CardSuit.Hearts, CardRank.Two),
            new(CardSuit.Diamonds, CardRank.Four),
            new(CardSuit.Hearts, CardRank.Three)
        };

        Assert.Equal(PokerCombinations.TwoPairs, PokerHandler.FindCombinations(testCards));
    }
    
    [Fact]
    public void RoyalFlushHandlerTest()
    {
        var testCards = new List<Card>
        {
            new(CardSuit.Clubs, CardRank.Queen),
            new(CardSuit.Clubs, CardRank.King),
            new(CardSuit.Clubs, CardRank.Ten),
            new(CardSuit.Clubs, CardRank.Jack),
            new(CardSuit.Clubs, CardRank.Ace)
        };

        Assert.Equal(PokerCombinations.RoyalFlush, PokerHandler.FindCombinations(testCards));
    }
    
    [Fact]
    public void FullHouseHandlerTest()
    {
        var testCards = new List<Card>
        {
            new(CardSuit.Clubs, CardRank.Two),
            new(CardSuit.Diamonds, CardRank.Three),
            new(CardSuit.Hearts, CardRank.Two),
            new(CardSuit.Diamonds, CardRank.Three),
            new(CardSuit.Hearts, CardRank.Three)
        };

        Assert.Equal(PokerCombinations.FullHouse, PokerHandler.FindCombinations(testCards));
    }
    
    [Fact]
    public void ExceptionAddTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        var dealer = new Dealer(new CardDeck());
        
        var strategy = new Fold();
        var player = new PokerPlayer("name", strategy);
        bank.CreateAccount(player);
        
        var pokerGame = new PokerGame(dealer, bank);

        var bet = new PokerBet(BetStatus.Active, 10);
        Assert.Throws<Exception>(() => pokerGame.JoinToGame(player, bet));
    }
    
    [Fact]
    public void AddTest()
    {
        var bankMock = new Mock<IBank>();
        var dealer = new Dealer(new CardDeck());
        var strategy = new Fold();
        var player = new PokerPlayer("name", strategy);

        bankMock.Setup(m => m.CheckTheAmountOfMoneyToBet(player, 100)).Returns(true);
        
        var pokerGame = new PokerGame(dealer, bankMock.Object);
        var bet = new PokerBet(BetStatus.Active, 100);
        pokerGame.JoinToGame(player, bet);
        
        bankMock.Verify(m => m.CheckTheAmountOfMoneyToBet(player, 100), Times.Once);
    }
    
    [Fact]
    public void FoldStrategyTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        var dealer = new Dealer(new CardDeck());
        
        var strategyMock = new Mock<Fold>();
        var player = new PokerPlayer("name", strategyMock.Object);
        bank.CreateAccount(player);
        bank.Deposit(player, 100);

        var pokerGame = new PokerGame(dealer, bank);
        var bet = new PokerBet(BetStatus.Active, 10);
        
        pokerGame.JoinToGame(player, bet);
        pokerGame.StartGame();
        
        strategyMock.Verify(m => m.BetChange(bet), Times.Once);
    }
    
    [Fact]
    public void CallStrategyTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        var dealer = new Dealer(new CardDeck());
        
        var strategyMock = new Mock<Call>();
        var player = new PokerPlayer("name", strategyMock.Object);
        bank.CreateAccount(player);
        bank.Deposit(player, 100);

        var pokerGame = new PokerGame(dealer, bank);
        var bet = new PokerBet(BetStatus.Active, 10);
        
        pokerGame.JoinToGame(player, bet);
        pokerGame.StartGame();
        
        strategyMock.Verify(m => m.BetChange(bet), Times.Once);
    }
}
  