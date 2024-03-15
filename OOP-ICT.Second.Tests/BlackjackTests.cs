using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class BlackjackTests
{
    [Fact]
    public void PayoutOfWinningTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        
        var player = Player.Builder().WithName("player").Build();
        bank.CreateAccount(player);
        
        var account = bank.GetAccount(player);

        var blackjack = new BlackjackCasino(bank);
        const uint bet = 10;
        blackjack.PayoutOfWinning(player, bet);
        
        Assert.Equal(bet, account.Balance);
    }

    [Fact]
    public void PayoutOfLossesTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        
        var player = Player.Builder().WithName("player").Build();
        bank.CreateAccount(player);
        
        var account = bank.GetAccount(player);

        var blackjack = new BlackjackCasino(bank);
        const uint bet = 10;
        blackjack.PayoutOfWinning(player, 2 * bet);
        blackjack.PayoutOfLosses(player, bet);
        
        Assert.Equal(bet, account.Balance);
    }
}