using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OpportunityCard : Card
{
    [SerializeField] int[] _StatusStatModifiers; //how card affects status
    public int[] StatusStatModifiers { get; }

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
}


