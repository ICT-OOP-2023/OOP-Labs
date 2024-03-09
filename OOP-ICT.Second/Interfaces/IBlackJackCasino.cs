using OOP_ICT.Second.Models;

namespace OOP_ICT.Second.Interfaces;

public interface IBlackjackCasino
{
    void PayWinning(Player player, decimal amount);
    void ChargeLoss(Player player, decimal amount);
    void ProcessBlackjack(Player player);
}