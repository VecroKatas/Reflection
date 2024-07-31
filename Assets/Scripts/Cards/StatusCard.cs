using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCard : Card
{
    [SerializeField] BStatModifier[] _BStatModifiers;
    [SerializeField] SStatModifier[] _SStatModifiers;

    void Play()
    {
        foreach (BStatModifier mod in _BStatModifiers)
        {
            BasicModifier mod1 = new BasicModifier(mod.stat, mod.Value, this);
            Stats.GetBasicStatByAbbreviation(mod.stat).AddModifier(mod1);
        }
        foreach (SStatModifier mod in _SStatModifiers)
        {
            StatusModifier mod1 = new StatusModifier(mod.stat, mod.Value, this);
            Stats.GetStatusStatByAbbreviation(mod.stat).AddModifier(mod1);
        }
    }
}
