using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class SStatCondition : Condition
{
    [SerializeField] SStats stat;
    [SerializeField] float MinValue;
    [SerializeField] float MaxValue;

    override
    public bool IsFullfilled()
    {
        if (Stats.GetStatusStatByAbbreviation(stat).Score >= MinValue
            && Stats.GetStatusStatByAbbreviation(stat).Score <= MaxValue) return true;
        else return false;
    }
}
