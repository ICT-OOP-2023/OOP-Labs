using OOP_ICT.Fourth.Abstraction;

namespace OOP_ICT.Fourth.Models.Strategies;

public class Raise : IStrategy
{
    private readonly uint _sum;
    public Raise(uint sum)
    {
        _sum = sum;
    }

    public virtual void BetChange(PokerBet bet)
    {
        bet.Sum = _sum;
    }
}