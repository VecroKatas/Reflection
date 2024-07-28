using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OpportunityCard : Card
{
    [SerializeField] int[] _StatusStatModifiers; //how card affects status
    public int[] StatusStatModifiers { get; }
}


