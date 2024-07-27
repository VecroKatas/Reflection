using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICard
{
    string Name { get; }
    string Description { get; }
    int CardID { get; }
    bool OnTheTable { get; set; }
    int PoolID { get; }

    //value, which determines the chance to be drawn from deck
    float Relevance();

    //Are all conditions for card to appear in the deck met
    bool CanBeDrawn();
}

public interface ITrigger
{
    bool IsTriggered();
}