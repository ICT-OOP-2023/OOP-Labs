using OOP_ICT.Abstractions;
using OOP_ICT.Second.Abstractions;

namespace OOP_ICT.Second.Models;

public class BlackjackCasino
{
    private readonly IBank _chipBank;

    public BlackjackCasino(IBank bank)
    {
        _chipBank = bank;
    }
    
    public void PayoutOfWinning(Person player, uint bet)
    {
        _chipBank.Deposit(player, bet);
    }

    public void PayoutOfLosses(Person player, uint bet)
    {
        _chipBank.Withdraw(player, bet);
    }

    public void BlackjackProcessing(Person player, uint bet)
    {
        _chipBank.Deposit(player, bet * 2);
    }
}