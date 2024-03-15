using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;

namespace OOP_ICT.Fourth.Models.Strategies;

public class Fold : IStrategy
{
    public virtual void BetChange(PokerBet bet)
    {
        bet.BetStatus = BetStatus.Inactive;
    }
}