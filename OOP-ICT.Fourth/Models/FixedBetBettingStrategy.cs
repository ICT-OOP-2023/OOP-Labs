using OOP_ICT.Fourth.Interfaces;

namespace OOP_ICT.Fourth.Models;

public class FixedBetBettingStrategy : IBettingStrategy
{
    private readonly decimal _fixedBetAmount;

    public FixedBetBettingStrategy(decimal betAmount)
    {
        if (betAmount <= 0)
        {
            throw new ArgumentException("Ставка должна быть положительным числом.");
        }

        _fixedBetAmount = betAmount;
    }

    public decimal GetBet()
    {
        return _fixedBetAmount;
    }
}