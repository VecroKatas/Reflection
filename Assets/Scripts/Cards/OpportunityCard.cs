using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OpportunityCard : Card
{
    [SerializeField] int[] _StatusStatModifiers; //how card affects status
    [SerializeField] int[] _FunValue; //Value, that describes how fun it would be for shadow to take the opportunity
    public int[] StatusStatModifiers { get; }
}


