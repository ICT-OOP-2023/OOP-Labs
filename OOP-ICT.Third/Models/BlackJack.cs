using OOP_ICT.Abstractions;
using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;
using OOP_ICT.Third.Abstractions;

namespace OOP_ICT.Third.models;

public class BlackJack
{
    private readonly Dealer _dealer;
    private readonly IBank _bank;
    private readonly IGameCalculator _calculator;
    private readonly Dictionary<Person, uint> _players = new();

    public BlackJack(Dealer dealer, IBank bank, IGameCalculator calculator)
    {
        _dealer = dealer;
        _bank = bank;
        _calculator = calculator;
    }
    
    public void JoinToGame(Person player, uint bet)
    {
        if (_bank.CheckTheAmountOfMoneyToBet(player, bet))
        {
            _players[player] = bet;
        }
        else
        {
            throw new Exception("Not enough money to bet");
        }
    }

    public void StartGame()
    {
        if (_players.Count == 0)
        {
            throw new Exception("No players in game");
        }
        
        for (var i = 0; i < 2; i++)
        {
            foreach (var pair in _players)
            {
                pair.Key.TakeCard(_dealer.Dealing());
            }
        }
        
        _dealer.TakeCard(_dealer.Dealing());

        foreach (var player in _players.Select(pair => pair.Key))
        {
            while (_calculator.TotalPowerOfCards(player) < 17)
            {
                player.TakeCard(_dealer.Dealing());
            }
        }

        while (_calculator.TotalPowerOfCards(_dealer) < 17)
        {
            _dealer.TakeCard(_dealer.Dealing());
        }
        
        Result();
    }

    private void Result()
    {
        var dealerTotalPower = TotalPower(_dealer);
        foreach (var (player, bet) in _players)
        {
            var playerTotalPower = TotalPower(player);
            if (playerTotalPower < dealerTotalPower || playerTotalPower > 21)
            {
                _bank.Withdraw(player, bet);
            }
            else
            {
                _bank.Deposit(player, bet);
            }
        }
    }

    private uint TotalPower(Person person)
    {
        return _calculator.TotalPowerOfCards(person);
    }
}