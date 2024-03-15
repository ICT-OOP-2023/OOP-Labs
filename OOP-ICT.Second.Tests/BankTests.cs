using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class BankTests
{
    [Fact]
    public void DepositTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        
        var player = Player.Builder().WithName("player").Build();
        bank.CreateAccount(player);
        var account = bank.GetAccount(player);
        
        const uint sum = 10;
        bank.Deposit(player, sum);
        Assert.Equal(sum, account.Balance);
    }

    [Fact]
    public void WithdrawTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        
        var player = Player.Builder().WithName("player").Build();
        bank.CreateAccount(player);
        var account = bank.GetAccount(player);
        
        account.Balance = 100;
        bank.Withdraw(player, 10);
        const uint sum = 90;
        Assert.Equal(sum, account.Balance);
    }

    [Fact]
    public void CheckTheAmountOfMoneyToBetTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        
        var player = Player.Builder().WithName("player").Build();
        bank.CreateAccount(player);
        
        Assert.False(bank.CheckTheAmountOfMoneyToBet(player, 10));
        
        bank.Deposit(player, 10);
        Assert.True(bank.CheckTheAmountOfMoneyToBet(player, 10));
    }

    [Fact]
    public void GetBalanceTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        
        var player = Player.Builder().WithName("player").Build();
        bank.CreateAccount(player);
        var account = bank.GetAccount(player);
        
        Assert.Equal(bank.GetBalance(player), account.Balance);
    }

    [Fact]
    public void GetAccountTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        
        var player = Player.Builder().WithName("player").Build();
        bank.CreateAccount(player);
        var account = bank.GetAccount(player);
        
        Assert.Equal(bank.GetAccount(player), account);
    }

    [Fact]
    public void RemoveAccountTest()
    {
        var factory = new AccountFactory();
        var bank = new Bank(factory);
        
        var player = Player.Builder().WithName("player").Build();
        bank.CreateAccount(player);
        bank.RemoveAccount(player);
        
        Assert.Throws<ArgumentNullException>(() => bank.GetAccount(player));
    }
}