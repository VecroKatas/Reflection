using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class CardsPlayedCondition : Condition
{
    [SerializeField] Card[] NeccesaryCards;

    override
    public bool IsFullfilled()
    {
        foreach (Card card in NeccesaryCards)
            if (!card.HasBeenPlayed) return false;
        return true;
    }
}
