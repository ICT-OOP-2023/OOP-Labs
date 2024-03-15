using OOP_ICT.Fourth.enums;

namespace OOP_ICT.Fourth.Models;

public class PokerBet
{
    public BetStatus BetStatus { get; set; }
    public uint Sum { get; set; }

    public PokerBet(BetStatus betStatus, uint sum)
    {
        BetStatus = betStatus;
        Sum = sum;
    }
}