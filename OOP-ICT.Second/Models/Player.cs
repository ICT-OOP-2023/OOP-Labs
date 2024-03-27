using OOP_ICT.Models;
using OOP_ICT.Second.Interfaces;

namespace OOP_ICT.Second.Models;

public class Player
{
    public Player(IPlayerAccount playerAccount)
    {
        Account = playerAccount;
    }

    public IPlayerAccount Account { get; }
    public Hand Hand { get; set; } = new();
    public decimal CurrentBet { get; private set; }

    public void PlaceBet(decimal amount)
    {
        if (amount > 0 && Account.Withdraw(amount))
        {
            CurrentBet = amount;
        }
    }

    public void ClearHand()
    {
        Hand = new Hand();
    }
}