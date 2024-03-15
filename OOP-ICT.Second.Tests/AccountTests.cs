using OOP_ICT.Second.Models;
using Xunit;

namespace OOP_ICT.Second.Tests;

public class AccountTests
{
    [Fact]
    public void AccountTest()
    {
        var factory = new AccountFactory();
        var player = Player.Builder().WithName("player").Build();
        var account = factory.CreateAccount(player);

        var newAccount = new Account(player);
        
        Assert.Equal(account.Owner, newAccount.Owner);
    }
}