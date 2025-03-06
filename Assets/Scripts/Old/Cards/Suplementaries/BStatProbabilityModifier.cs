using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
