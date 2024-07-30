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

    [SerializeField] protected BStatProbabilityModifier[] _BStatProbabilityModifiers;
    [SerializeField] protected SStatProbabilityModifier[] _SStatProbabilityModifiers;
    [SerializeField] protected CurrentTurnProbabilityModifier[] _CurrentTurnProbabilityModifiers;

    [SerializeField] protected BStatCondition[] _BStatConditions;
    [SerializeField] protected SStatCondition[] _SStatConditions;
    [SerializeField] protected CardsPlayedCondition[] _CardsPlayedConditions;
    [SerializeField] protected CurrentTurnCondition[] _CurrentTurnConditions;

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
    public float Relevance()
    {
        float relevance = 0;
        if (this.CanBeDrawn())
        {
            foreach (BStatProbabilityModifier modifier in _BStatProbabilityModifiers)
                relevance += modifier.AddedChance();
            foreach (SStatProbabilityModifier modifier in _SStatProbabilityModifiers)
                relevance += modifier.AddedChance();
            foreach (CurrentTurnProbabilityModifier modifier in _CurrentTurnProbabilityModifiers)
                relevance *= modifier.ChanceMultiplier;
            return relevance;
        }
        else return 0;
    }

    //Are all conditions for card to appear in the deck met
    public bool CanBeDrawn()
    {
        BStatCondition FalseCondition1 = _BStatConditions.FirstOrDefault(condition => !condition.IsFullfilled());
        if (FalseCondition1 != null) return false;
        SStatCondition FalseCondition2 = _SStatConditions.FirstOrDefault(condition => !condition.IsFullfilled());
        if (FalseCondition2 != null) return false;
        CardsPlayedCondition FalseCondition3 = _CardsPlayedConditions.FirstOrDefault(condition => !condition.IsFullfilled());
        if (FalseCondition3 != null) return false;
        CurrentTurnCondition FalseCondition4 = _CurrentTurnConditions.FirstOrDefault(condition => !condition.IsFullfilled());
        if (FalseCondition4 != null) return false;
        return true;
    }
}
