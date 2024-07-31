using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrawableCard : Card
{
    [SerializeField] protected BStatProbabilityModifier[] _BStatProbabilityModifiers;
    [SerializeField] protected SStatProbabilityModifier[] _SStatProbabilityModifiers;
    [SerializeField] protected CurrentTurnProbabilityModifier[] _CurrentTurnProbabilityModifiers;

    [SerializeField] protected Condition[] _Conditions;

    public int Relevance()
    {
        float relevance = 0;
        if (this.CanBeDrawn())
        {
            foreach (BStatProbabilityModifier modifier in _BStatProbabilityModifiers)
                relevance += modifier.AddedChance();
            foreach (SStatProbabilityModifier modifier in _SStatProbabilityModifiers)
                relevance += modifier.AddedChance();
            foreach (CurrentTurnProbabilityModifier modifier in _CurrentTurnProbabilityModifiers)
                relevance *= modifier.ChanceMultiplier;
            return System.Convert.ToInt32(relevance);
        }      
        else return 0;
    }

    //Are all conditions for card to appear in the deck met
    public bool CanBeDrawn()
    {
        Condition FalseCondition = _Conditions.FirstOrDefault(condition => !condition.IsFullfilled());
        if (FalseCondition != null) return false;
        return true;
    }
}
