using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Condition : ScriptableObject
{
    public bool IsFullfilled()
    {
        return false;
    }
}

[System.Serializable]
public class CardSummoner
{
    [SerializeField] Card _SummonedCard;
    [SerializeField] int _SummonChance;
    public int SummonChance => _SummonChance;
    public Card SummonedCard => _SummonedCard;
}



