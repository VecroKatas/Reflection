using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    private Stats _stats = Stats.GetInstance();

    private void Start()
    {
        _stats.InitiateBasicStats(new [] {10, 10, 10, 10, 10, 10, 10});
    }
}

public class Stats
{
    private Stats() { }

    private static Stats _instance;
    
    private static readonly object _lock = new object();

    public static Stats GetInstance()
    {
        if (_instance == null)
            lock (_lock)
                if (_instance == null)
                {
                    _instance = new Stats();
                }

        return _instance;
    }



    private bool initiated = false;

    #region Basic Stats
    public struct BasicStats
    {
        public static BasicStat Emotionality;
        public static BasicStat Intelligence;
        public static BasicStat Ego;
        public static BasicStat NTNT;
        public static BasicStat Creativity;
        public static BasicStat BodyFunctionality;
        public static BasicStat BodyDurability;
    }

    public void InitiateBasicStats(int[] scores)
    {
        if (initiated)
            return;
        initiated = true;
        
        BasicStats.Emotionality = new BasicStat(BStats.Em, scores[0], "Emotionality", "How much emotions influence character's decisions.");
        BasicStats.Intelligence = new BasicStat(BStats.Int, scores[1], "Intelligence", "How logical and smart character is.");
        BasicStats.Ego = new BasicStat(BStats.Ego, scores[2], "Ego", "How self-centered character is.");
        BasicStats.NTNT = new BasicStat(BStats.It, scores[3], "Not this not this", "It can't be put to words.");
        BasicStats.Creativity = new BasicStat(BStats.Cr, scores[4], "Creativity", "How unpredictable character is.");
        BasicStats.BodyFunctionality = new BasicStat(BStats.Bf, scores[5], "Body functionality", "How big of the ultimate unit character's body is.");
        BasicStats.BodyDurability = new BasicStat(BStats.Bd, scores[6], "Body durability", "How durable character's body is.");
    }
    #endregion

    #region Status Stats
    public struct StatusStats
    {
        public static StatusStat Corruption;
        public static StatusStat Happiness;
        public static StatusStat Health;
        public static StatusStat Psyche;
        public static StatusStat Satisfaction;
        public static StatusStat Sociability;
        public static StatusStat Volition;
        public static StatusStat Wealth;
    }

    public void InitiateStatusStats(float[] scores)
    {
        if (initiated)
            return;
        initiated = true;
        
        StatusStats.Corruption = new StatusStat(SStats.Cor, scores[0], "Corruption", "How good of a person the character is.");
        StatusStats.Happiness = new StatusStat(SStats.Hap, scores[1], "Happiness", "How happy character is in the moment.");
        StatusStats.Health = new StatusStat(SStats.Hth, scores[2], "Health", "How healthy character is.");
        StatusStats.Psyche = new StatusStat(SStats.Ps, scores[3], "Psyche", "How healthy character's mind is.");
        StatusStats.Satisfaction = new StatusStat(SStats.Sat, scores[4], "Satisfaction", "How satisfied with his life the character is.");
        StatusStats.Sociability = new StatusStat(SStats.Soc, scores[5], "Sociability", "How good with people character is.");
        StatusStats.Volition = new StatusStat(SStats.Vol, scores[6], "Volition", "How likely to take action character is.");
        StatusStats.Wealth = new StatusStat(SStats.Wth, scores[6], "Wealth", "How wealthy character is.");
    }
    #endregion
}
#region Basic stats
public class BasicModifier
{
    public int Value { get; }
    public BStats Stat;
    // Add reference on the card

    public BasicModifier(BStats stat, int value)
    {
        Value = value;
        Stat = stat;
        //card
    }
}

public enum BStats
{
    Em, Int, Ego, It, Cr, Bf, Bd
}

public class BasicStat
{
    public BStats Abbreviation;
    public string Name;
    public string Description;
    public int StartingScore { get; }
    public List<BasicModifier> Modifiers;

    private int instantModifierScore = 0;

    public int Score
    {
        get
        {
            int modScore = 0;
            foreach (var mod in Modifiers)
            {
                modScore += mod.Value;
            }

            return StartingScore + modScore + instantModifierScore;
        }
    }

    public BasicStat(BStats abbreviation, int startingScore, string name, string description)
    {
        Abbreviation = abbreviation;
        Name = name;
        Description = description;
        StartingScore = startingScore;
    }

    public void AddModifier(BasicModifier modifier)
    {
        if (!Modifiers.Contains(modifier))
            Modifiers.Add(modifier);
    }

    public void AddInstantModifier(int value)
    {
        instantModifierScore += value;
    }
}
#endregion

#region Status stats
public enum SStats
{
    Cor, Hap, Hth, Ps, Sat, Soc, Vol, Wth
}

public class StatusModifier
{
    public float Value { get; }
    public SStats Stat;
    // card reference
    
    public StatusModifier(SStats stat, float value)
    {
        Value = value;
        Stat = stat;
        //card
    }
}

public class StatusStat
{
    public SStats Abbreviation;
    public string Name;
    public string Description;

    private float minScore = 0;
    private float maxScore = 100;

    public float StartingScore { get; }
    public List<StatusModifier> Modifiers;

    private float instantModifierScore = 0;

    public float Score
    {
        get
        {
            float modScore = 0;
            foreach (var mod in Modifiers)
            {
                modScore += mod.Value;
            }

            float result = StartingScore + modScore + instantModifierScore;

            if (result <= minScore || result >= maxScore)
                throw new Exception("Game ended");
            
            return StartingScore + modScore + instantModifierScore;
        }
    }

    public StatusStat(SStats abbreviation, float startingScore, string name, string description)
    {
        Abbreviation = abbreviation;
        Name = name;
        Description = description;
        StartingScore = startingScore;
    }

    public void AddModifier(StatusModifier modifier)
    {
        if (!Modifiers.Contains(modifier))
            Modifiers.Add(modifier);
    }

    public void AddInstantModifier(float value)
    {
        instantModifierScore += value;
    }
}
#endregion