using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Card : ScriptableObject, ICard
{
    [SerializeField] protected string _Name;
    [SerializeField] protected string _Description;
    [SerializeField] protected int _CardID;
    [SerializeField] protected int[] _PoolIDs; //Pools from which card can be drawn

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
    public int[] PoolIDs => _PoolIDs;
    public CardSummoner[] CardSummoners => _CardSummoners;

    public bool OnTheTable { get; set; }
    //value, which determines the chance to be drawn from deck
    public int Relevance()
    {
        return 0;
    }

    //Are all conditions for card to appear in the deck met
    public bool CanBeDrawn()
    {     
        return false;
    }

    public void Play()
    {

    }
}
