using OOP_ICT.Fourth.Interfaces;
using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Models;

public class PokerCasino : IPokerCasino
{
    private readonly PokerBank _pokerBank;

    public PokerCasino(PokerBank bank)
    {
        _pokerBank = bank;
    }

    public void PayWinning(Player player, decimal amount)
    {
        _pokerBank.Deposit(player.Account, amount);
    }

    public void ChargeLoss(Player player, decimal amount)
    {
        _pokerBank.Withdraw(player.Account, amount);
    }
    
}