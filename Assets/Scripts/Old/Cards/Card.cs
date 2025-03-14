using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public abstract class Card : ScriptableObject
{
    [SerializeField] protected string _Name;
    [SerializeField] protected string _Description;
    [SerializeField] protected int _CardID;
    [SerializeField] protected int[] _PoolIDs; //Pools from which card can be drawn
    protected bool _HasBeenPlayed = false;

    [SerializeField] protected CardSummoner[] _CardSummoners;
    public string Name => _Name;
    public string Description => _Description;
    // temporarily changed
    //public int CardID => _CardID;
    public int CardID
    {
        get { return _CardID; }
        set { _CardID = value; }
    }

    public bool HasBeenPlayed
    {
        get { return _HasBeenPlayed; }
        set { _HasBeenPlayed = value; }
    }
    public int[] PoolIDs => _PoolIDs;
    public CardSummoner[] CardSummoners => _CardSummoners;

    public bool OnTheTable { get; set; }
    //value, which determines the chance to be drawn from deck
    public abstract int Relevance();

    //Are all conditions for card to appear in the deck met
    public abstract bool CanBeDrawn();

    public abstract int Play(); 
}
