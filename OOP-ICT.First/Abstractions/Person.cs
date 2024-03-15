using OOP_ICT.Models;

namespace OOP_ICT.Abstractions;

public abstract class Person
{
    public string Name { get; }
    private readonly List<Card> _hand = new();

    protected Person(string name = "Incognito")
    {
        Name = name;
    }

    public void TakeCard(Card card)
    {
        _hand.Add(card);
    }
    
    public IEnumerable<Card> GetCards()
    {
        return _hand;
    }

    public override string ToString()
    {
        return Name;
    }
}