using OOP_ICT.Fourth.Abstraction;

namespace OOP_ICT.Fourth.Models.Strategies;

public class Call : IStrategy
{
    public virtual void BetChange(PokerBet bet) {}
}