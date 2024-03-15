using OOP_ICT.Abstractions;
using OOP_ICT.Fourth.Abstraction;

namespace OOP_ICT.Fourth.Models;

public class PokerPlayer : Person
{
    public PokerPlayer(string name, IStrategy strategy) : base(name)
    {
        _strategy = strategy;
    }

    private IStrategy _strategy;

    public void BetChange(PokerBet bet)
    {
        _strategy.BetChange(bet);
    } 
    public void SetStrategy(IStrategy strategy)
    {
        _strategy = strategy;
    }
}