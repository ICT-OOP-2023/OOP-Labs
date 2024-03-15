using Moq;
using OOP_ICT.enums;
using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.models;
using Xunit;

namespace OOP_ICT.Third.Tests;

public class BlackjackTests
{
    [Fact]
    public void CalculatorTest()
    {
        var calculator = new BlackjackCalculator();
        const uint i = 11;
        const uint j = 10;
        const uint k = 2;
        Assert.Equal(i, calculator.CardPower(new Card(CardSuit.Clubs, CardRank.Ace)));
        Assert.Equal(j, calculator.CardPower(new Card(CardSuit.Clubs, CardRank.Queen)));
        Assert.Equal(k, calculator.CardPower(new Card(CardSuit.Clubs, CardRank.Two)));
    }
    
    [Fact]
    public void ExceptionAddTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        var dealer = new Dealer(new CardDeck());
        var player = new Player.PlayerBuilder().WithName("Player").Build();
        bank.CreateAccount(player);
        
        var calculator = new BlackjackCalculator();
        var blackjack = new BlackJack(dealer, bank, calculator);
        
        Assert.Throws<Exception>(() => blackjack.JoinToGame(player, 100));
    }

    [Fact]
    public void AddTest()
    {
        var bankMock = new Mock<IBank>();
        var dealer = new Dealer(new CardDeck());
        var player = new Player.PlayerBuilder().WithName("Player").Build();
        
        var calculator = new BlackjackCalculator();
        var blackjack = new BlackJack(dealer, bankMock.Object, calculator);

        bankMock.Setup(m => m.CheckTheAmountOfMoneyToBet(player, 100)).Returns(true);
        blackjack.JoinToGame(player, 100);
        
        bankMock.Verify(m => m.CheckTheAmountOfMoneyToBet(player, 100), Times.Once);
    }
}
