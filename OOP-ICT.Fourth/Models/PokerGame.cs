using OOP_ICT.Abstractions;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Models;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Fourth.Models;

public class PokerGame
{
    private readonly Dealer _dealer;
    private readonly IBank _bank;
    private readonly Dictionary<PokerPlayer, PokerBet> _players = new();

    public PokerGame(Dealer dealer, IBank bank)
    {
        _dealer = dealer;
        _bank = bank;
    }
    
    public void JoinToGame(PokerPlayer player, PokerBet bet)
    {
        if (_bank.CheckTheAmountOfMoneyToBet(player, bet.Sum))
        {
            _players[player] = bet;
        }
        else
        {
            throw new Exception("Not enough money to bet");
        }
    }

    public void LeaveGame(PokerPlayer player)
    {
        _players.Remove(player);
    }

    public void StartGame()
    {
        if (_players.Count == 0)
        {
            throw new Exception("No players in game");
        }
        
        DealCardsIntoHands(2);
        var table = DealCardsToTable(5);

        Betting();

        var winner = DetermineWinner(table);

        uint totalBank = 0;

        foreach (var (player, bet) in _players)
        {
            if (player != winner)
            {
                _bank.Withdraw(player, bet.Sum);
                totalBank += bet.Sum;
            }
        }

        if (winner != _dealer)
        {
            _bank.Deposit(winner, totalBank);
        }
    }

    private Person DetermineWinner(List<Card> table)
    {
        var persons = new List<Person>();

        foreach (var pair in _players.Where(pair => pair.Value.BetStatus == BetStatus.Active))
        {
            foreach (var card in table)
            {
                pair.Key.TakeCard(card);
            }
            
            persons.Add(pair.Key);
        }
        
        foreach (var card in table)
        {
            _dealer.TakeCard(card);
        }
        
        persons.Add(_dealer);

        return PokerHandler.DetermineWinner(persons);
    }

    private void Betting()
    {
        foreach (var pair in _players)
        {
            pair.Key.BetChange(pair.Value);
        }
    }
    private void DealCardsIntoHands(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            foreach (var pair in _players)
            {
                pair.Key.TakeCard(_dealer.Dealing());
            }
            _dealer.TakeCard(_dealer.Dealing());
        }
    }

    private List<Card> DealCardsToTable(int amount)
    {
        var list = new List<Card>();
        for (var i = 0; i < amount; i++)
        {
            list.Add(_dealer.Dealing());
        }

        return list;
    }
}