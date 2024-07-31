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

[CreateAssetMenu]
[System.Serializable]
public class BStatCondition : Condition
{
    [SerializeField] BStats stat;
    [SerializeField] int MinValue;
    [SerializeField] int MaxValue;

    public bool IsFullfilled()
    {
        if (Stats.GetBasicStatByAbbreviation(stat).Score >= MinValue 
            && Stats.GetBasicStatByAbbreviation(stat).Score <= MaxValue) return true;
        else return false;
    }
}

[CreateAssetMenu]
[System.Serializable]
public class SStatCondition : Condition
{
    [SerializeField] SStats stat;
    [SerializeField] float MinValue;
    [SerializeField] float MaxValue;

    public bool IsFullfilled()
    {
        if (Stats.GetStatusStatByAbbreviation(stat).Score >= MinValue 
            && Stats.GetStatusStatByAbbreviation(stat).Score <= MaxValue) return true;
        else return false;
    }
}

[CreateAssetMenu]
[System.Serializable]
public class CardsPlayedCondition : Condition
{
    [SerializeField] ICard[] NeccesaryCards;

    public bool IsFullfilled()
    {
        //Checks if table or discard pile have ALL listed cards
        return true;
    }
}

[CreateAssetMenu]
[System.Serializable]
public class CurrentTurnCondition : Condition
{
    [SerializeField] int MinTurn;
    [SerializeField] int MaxTurn;

    public bool IsFullfilled()
    {
        //Checks turn controller or smth
        return true;
    }
}

[CreateAssetMenu]
[System.Serializable]
public class BStatProbabilityModifier : ScriptableObject
{
    [SerializeField] BStats stat;
    [SerializeField] float _ChanceMultiplier;
    
    public float AddedChance()
    {
        return Stats.GetBasicStatByAbbreviation(stat).Score * _ChanceMultiplier;
    }
}

[CreateAssetMenu]
[System.Serializable]
public class SStatProbabilityModifier : ScriptableObject
{
    [SerializeField] SStats stat;
    [SerializeField] float _ChanceMultiplier;
    public float AddedChance()
    {
        return Stats.GetStatusStatByAbbreviation(stat).Score * _ChanceMultiplier;
    }
}

[CreateAssetMenu]
[System.Serializable]
public class CurrentTurnProbabilityModifier : ScriptableObject
{
    [SerializeField] int MinTurn;
    [SerializeField] int MaxTurn;
    [SerializeField] float _ChanceMultiplier;
    public float ChanceMultiplier => _ChanceMultiplier;
}

[System.Serializable]
public class CardSummoner
{
    [SerializeField] Card _SummonedCard;
    [SerializeField] int _SummonChance;
    public int SummonChance => _SummonChance;
    public Card SummonedCard => _SummonedCard;
}