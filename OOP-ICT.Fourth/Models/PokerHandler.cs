using OOP_ICT.Abstractions;
using OOP_ICT.Fourth.Abstraction;
using OOP_ICT.Fourth.enums;
using OOP_ICT.Fourth.Models.CombinationHandlers;
using OOP_ICT.Models;

namespace OOP_ICT.Fourth.Models;

public static class PokerHandler
{
    private static readonly List<ICombinationHandler> Handlers = new()
    {
        new RoyalFlushHandler(),
        new StraightFlushHandler(),
        new FourOfKindHandler(),
        new FullHouseHandler(),
        new FlushHandler(),
        new StraightHandler(),
        new ThreeOfKindHandler(),
        new TwoPairsHandler(),
        new OnePairHandler(),
        new HighHandHandler()
    };
    
    public static Person DetermineWinner(List<Person> persons)
    {
        var winningPerson = persons[0]; 
        var highestHandType = PokerCombinations.HighHand;

        foreach (var person in persons)
        {
            var result = FindCombinations(person.GetCards());

            if (result > highestHandType)
            {
                winningPerson = person;
                highestHandType = result;
            }
        }

        return winningPerson;
    }
    
    public static PokerCombinations FindCombinations(IEnumerable<Card> hand)
    {
        foreach (var handler in Handlers)
        {
            var result = handler.Handle(hand.ToList());
            if (result != PokerCombinations.Null)
            {
                return result;
            }
        }
        
        return PokerCombinations.Null;
    }
}