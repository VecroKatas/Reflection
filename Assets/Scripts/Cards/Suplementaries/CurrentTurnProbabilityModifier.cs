using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class CurrentTurnProbabilityModifier : ScriptableObject
{
    [SerializeField] int MinTurn;
    [SerializeField] int MaxTurn;
    [SerializeField] float _ChanceMultiplier;
    public float ChanceMultiplier => _ChanceMultiplier;
}
