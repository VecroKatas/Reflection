using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class BStatCondition : Condition
{
    [SerializeField] BStats stat;
    [SerializeField] int MinValue;
    [SerializeField] int MaxValue;

    override
    public bool IsFullfilled()
    {
        if (Stats.GetBasicStatByAbbreviation(stat).Score >= MinValue
            && Stats.GetBasicStatByAbbreviation(stat).Score <= MaxValue) return true;
        else return false;
    }
}
