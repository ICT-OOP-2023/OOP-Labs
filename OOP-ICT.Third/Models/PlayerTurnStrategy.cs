using OOP_ICT.Models;
using OOP_ICT.Second.Models;
using OOP_ICT.Third.Interfaces;

namespace OOP_ICT.Third.Models;

public class PlayerTurnStrategy : ITurnStrategy
{
    private readonly Func<string, bool> _userPrompt;
    private readonly IDealer _dealer;

    public PlayerTurnStrategy(Func<string, bool> userPrompt, IDealer dealer)
    {
        _userPrompt = userPrompt;
        _dealer = dealer;
    }

    public void PerformTurn(Hand hand)
    {
        while (hand.CalculateHandValue() < 21 && _userPrompt.Invoke(""))
        {
            hand.AddCard(_dealer.DealCards(1).First());
        }
    }
}