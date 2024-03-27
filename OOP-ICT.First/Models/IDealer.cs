﻿namespace OOP_ICT.Models;

public class IDealer
{
    public IDealer()
    {
        Deck = new Deck();
        Deck.Shuffle();
    }

    public Deck Deck { get; }

    public IReadOnlyCollection<Card> DealCards(int count)
    {
        var dealtCards = new List<Card>();
        for (var i = 0; i < count; i++)
        {
            dealtCards.Add(Deck.DrawCard());
        }

        return dealtCards;
    }
}