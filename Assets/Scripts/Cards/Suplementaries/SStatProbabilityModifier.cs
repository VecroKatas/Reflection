using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
