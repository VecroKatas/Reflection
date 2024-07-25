using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICard
{ 
    int CardID { get; }
    bool OnTheTable { get; set; }

    //value, which determines the chance to be drawn from deck
    float Relevance();

    //Are all conditions for card to appear in the deck met
    bool CanBeDrawn();
}

public class Card : ScriptableObject, ICard
{
    protected string Name;
    protected string Description;
    protected int _CardID;
    public int CardID { get; }
    public bool OnTheTable { get; set; }

    public Card(string Name, string Description, int ID)
    {
        this.Name = Name;
        this.Description = Description;
        this.CardID = ID;
    }
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
        return true;
    }
}

public class OpportunityCard : Card
{
    int[] PrerequisiteCardIDs; //cards that needed for the card to unlock;
    int[] MinimalStats; //minimal value of the stat for card to appear on the table;

    //Modifier[] Modifiers - when on table, affects stats

    public OpportunityCard(string Name, string Description, int ID, params int[] IDs) : base(Name, Description, ID)
    {
        this.PrerequisiteCardIDs = IDs;
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
        return true;
    }
}
