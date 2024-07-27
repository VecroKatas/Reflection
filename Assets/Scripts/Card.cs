using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OpportunityCard : ScriptableObject, ICard
{
    [SerializeField] public string Name { get; }
    [SerializeField] public string Description { get; }

    [SerializeField] public int CardID { get; }
    [SerializeField] public bool OnTheTable { get; set; }
    [SerializeField] public int[] StatusStatModifiers { get; }
    [SerializeField] public int[] ProbabilityModifiers { get; }
    public ITrigger[] Prerequisites { get; }
    [SerializeField] public int PoolID { get; }
    public ICard[] SummonCards { get; }


    public OpportunityCard(string Name, string Description, int ID, int PoolID, int[] StatusStatModifiers, params ITrigger[] triggers)
    {
        this.Name = Name;
        this.Description = Description;
        this.CardID = ID;
        this.Prerequisites = triggers;
        this.StatusStatModifiers = StatusStatModifiers;
        this.PoolID = PoolID;
    }

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
        foreach (ITrigger trigger in Prerequisites)
            if (!trigger.IsTriggered()) return false;
        return true;
    }
}


