using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    public string Name { get; }
    public string Description { get; }
    public int CardID { get; }
    public bool OnTheTable { get; set; }
    public bool HasBeenPlayed { get; set; }
    public int[] PoolIDs { get; }
    public CardSummoner[] CardSummoners { get; }

    //value, which determines the chance to be drawn from deck
    int Relevance();

    //Are all conditions for card to appear in the deck met
    bool CanBeDrawn();

    int Play();
}

