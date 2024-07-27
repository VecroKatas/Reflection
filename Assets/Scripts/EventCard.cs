using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventCard : Card
{
    [SerializeField] int _TimeOnTable; //how long card would be on table before being discarded

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


