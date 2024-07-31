using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class OpportunityCard : DrawableCard
{
    [SerializeField] int[] _StatusStatModifiers; //how card affects status
    [SerializeField] int[] _FunValue; //Value, that describes how fun it would be for shadow to take the opportunity
    [SerializeField] int[] _UsefulValue; //Value, that describes how good and proficient it would be for shadow to take the opportunity
    public int[] FunValue => _FunValue;
    public int[] UsefulValue => _UsefulValue;

    public void Play()
    {
        Stats.StatusStats.Corruption.AddInstantModifier(_StatusStatModifiers[0]);
        Stats.StatusStats.Happiness.AddInstantModifier(_StatusStatModifiers[1]);
        Stats.StatusStats.Health.AddInstantModifier(_StatusStatModifiers[2]);
        Stats.StatusStats.Psyche.AddInstantModifier(_StatusStatModifiers[3]);
        Stats.StatusStats.Satisfaction.AddInstantModifier(_StatusStatModifiers[4]);
        Stats.StatusStats.Sociability.AddInstantModifier(_StatusStatModifiers[5]);
        Stats.StatusStats.Volition.AddInstantModifier(_StatusStatModifiers[6]);
        Stats.StatusStats.Wealth.AddInstantModifier(_StatusStatModifiers[7]);

        foreach (CardSummoner sumon in _CardSummoners)
        {
            int Determinant = Random.Range(0, 100);
            if (sumon.SummonChance > Determinant)
            {
                sumon.SummonedCard.Play();
                break;
            }
        }
    }
}


