using OOP_ICT.Abstractions;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class Bank : IBank
{
    private readonly Dictionary<Person, IAccount> _accounts = new();
    private readonly IAccountFactory _accountFactory;

    public Bank(IAccountFactory accountFactory)
    {
        _accountFactory = accountFactory;
    }

    public void Deposit(Person player, uint sum)
    {
        CheckingForAvailability(player);
        GetAccount(player).Balance += sum;
    }

    public void Withdraw(Person player, uint sum)
    {
        CheckForSufficientBalance(player, sum);
        GetAccount(player).Balance -= sum;
    }

    public bool CheckTheAmountOfMoneyToBet(Person player, uint sum)
    {
        CheckingForAvailability(player);
        return GetBalance(player) >= sum;
    }

    public uint GetBalance(Person player)
    {
        CheckingForAvailability(player);
        return GetAccount(player).Balance;
    }

    public IAccount GetAccount(Person player)
    {
        CheckingForAvailability(player);
        return _accounts[player];
    }

    public void CreateAccount(Person player)
    {
        if (_accounts.ContainsKey(player))
        {
            throw new Exception($"Account {player} already exists");
        }

        _accounts[player] = _accountFactory.CreateAccount(player);
    }

    public void RemoveAccount(Person player)
    {
        CheckingForAvailability(player);
        _accounts.Remove(player);
    }

    private void CheckingForAvailability(Person player)
    {
        if (!_accounts.ContainsKey(player))
        {
            throw new ArgumentNullException($"Player {player} doesn't have account");
        }
    }

    private void CheckForSufficientBalance(Person player, uint sum)
    {
        CheckingForAvailability(player);
        if (sum > _accounts[player].Balance)
        {
            throw new Exception($"Player {player} doesn't have enough money");
        }
    }
}