using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject, ICard
{
    [SerializeField] protected string _Name;
    [SerializeField] protected string _Description;
    [SerializeField] protected int _CardID;
    [SerializeField] protected bool _OnTheTable;
    [SerializeField] protected int[] _PoolIDs; //Pools from which card can be drawn
    [SerializeField] protected int[] _ProbabilityModifiers; //how stats affect probability of drawing a card
    [SerializeField] protected int[] _PrerequisiteIDs; //Prerequisite triggers for card to be drawn
    [SerializeField] protected int[] _SummonCardIDs;
    public string Name { get; }
    public string Description { get; }
    public int CardID { get; }
    public bool OnTheTable { get; set; }
    public int[] ProbabilityModifiers { get; }
    public int[] PrerequisiteIDs { get; }
    public int[] PoolIDs { get; }
    public int[] SummonCardIDs { get; }

    //value, which determines the chance to be drawn from deck
    public float Relevance()
    {
        float relevance = 0;
        if (this.CanBeDrawn())
        {
            //smth like relevance += Stats.Emotionality.GetValue() * StatModifiers[0] for each stat
            return relevance;
        }
        else return 0;
    }

    //Are all conditions for card to appear in the deck met
    public bool CanBeDrawn()
    {
        ITrigger[] allTriggers = Resources.LoadAll<Trigger>("");
        foreach (ITrigger trigger in allTriggers)
            foreach (int triggerID in this._PrerequisiteIDs)
                if (trigger.ID == triggerID && !trigger.IsTriggered) return false;
        return true;
    }
}
