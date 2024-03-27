using OOP_ICT.Second.Models;

namespace OOP_ICT.Fourth.Interfaces;

public interface IPokerCasino
{
    public void PayWinning(Player player, decimal amount);
    public void ChargeLoss(Player player, decimal amount);
}