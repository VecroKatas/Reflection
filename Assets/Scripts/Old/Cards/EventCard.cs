using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EventCard : DrawableCard
{
    [SerializeField] int _TimeOnTable; //how long card would be on table before being discarded
    [SerializeField] int _RaundsBeetwenTicks; //number of rounds that passes beetwen provoking the eefect of the card

    [SerializeField] int[] _StatusStatModifiersWhenPlayed;
    [SerializeField] int[] _StatusStatModifiersPerTick; 
    [SerializeField] CardSummoner[] _CardsSummonPerTick;

    public int[] StatusStatModifiers => _StatusStatModifiersPerTick;
    public CardSummoner[] CardsSummonPerTick => _CardsSummonPerTick;

    override
    public int Play()
    {
        this._HasBeenPlayed = true;
        StatusModifier cor = new StatusModifier(SStats.Cor, _StatusStatModifiersWhenPlayed[0], this);
        StatusModifier hap = new StatusModifier(SStats.Hap, _StatusStatModifiersWhenPlayed[0], this);
        StatusModifier hth = new StatusModifier(SStats.Hth, _StatusStatModifiersWhenPlayed[0], this);
        StatusModifier ps = new StatusModifier(SStats.Ps, _StatusStatModifiersWhenPlayed[0], this);
        StatusModifier sat = new StatusModifier(SStats.Sat, _StatusStatModifiersWhenPlayed[0], this);
        StatusModifier soc = new StatusModifier(SStats.Soc, _StatusStatModifiersWhenPlayed[0], this);
        StatusModifier vol = new StatusModifier(SStats.Vol, _StatusStatModifiersWhenPlayed[0], this);
        StatusModifier wth = new StatusModifier(SStats.Wth, _StatusStatModifiersWhenPlayed[0], this);
        Stats.StatusStats.Corruption.AddModifier(cor);
        Stats.StatusStats.Happiness.AddModifier(hap);
        Stats.StatusStats.Health.AddModifier(hth);
        Stats.StatusStats.Psyche.AddModifier(ps);
        Stats.StatusStats.Satisfaction.AddModifier(sat);
        Stats.StatusStats.Sociability.AddModifier(soc);
        Stats.StatusStats.Volition.AddModifier(vol);
        Stats.StatusStats.Wealth.AddModifier(wth);
       
        foreach (CardSummoner sumon in _CardSummoners)
        {
            int Determinant = Random.Range(0, 100);
            if (sumon.SummonChance > Determinant)
                return sumon.SummonedCard.CardID;
        }
        return -1;
    }

    public int OnTick()
    {
        Stats.StatusStats.Corruption.AddInstantModifier(_StatusStatModifiersPerTick[0]);
        Stats.StatusStats.Happiness.AddInstantModifier(_StatusStatModifiersPerTick[1]);
        Stats.StatusStats.Health.AddInstantModifier(_StatusStatModifiersPerTick[2]);
        Stats.StatusStats.Psyche.AddInstantModifier(_StatusStatModifiersPerTick[3]);
        Stats.StatusStats.Satisfaction.AddInstantModifier(_StatusStatModifiersPerTick[4]);
        Stats.StatusStats.Sociability.AddInstantModifier(_StatusStatModifiersPerTick[5]);
        Stats.StatusStats.Volition.AddInstantModifier(_StatusStatModifiersPerTick[6]);
        Stats.StatusStats.Wealth.AddInstantModifier(_StatusStatModifiersPerTick[7]);

        foreach (CardSummoner sumon in _CardsSummonPerTick)
        {
            int Determinant = Random.Range(0, 100);
            if (sumon.SummonChance > Determinant)
                return sumon.SummonedCard.CardID;
        }
        return -1;
    }
}


