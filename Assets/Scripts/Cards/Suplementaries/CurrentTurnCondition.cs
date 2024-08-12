using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class CurrentTurnCondition : Condition
{
    [SerializeField] int MinTurn;
    [SerializeField] int MaxTurn;

    override
    public bool IsFullfilled()
    {
        //Checks turn controller or smth
        return true;
    }
}
