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

    public struct StatusStats
    {
        
    }
}

public class BasicModifier
{
    public int Value { get; }
    public BStats Stat;
}

public enum BStats
{
    Em, Int, Ego, It, Cr, Bf, Bd
}

public class BasicStat
{
    public BStats Abbreviation;
    public string Name;
    private string Description;
    public int StartingScore { get; }
    public List<BasicModifier> Modifiers;

    public int Score
    {
        get
        {
            int modScore = 0;
            foreach (var mod in Modifiers)
            {
                modScore += mod.Value;
            }

            return StartingScore + modScore;
        }
    }

    public BasicStat(BStats abbreviation, int startingScore, string name, string description)
    {
        Abbreviation = abbreviation;
        Name = name;
        Description = description;
        StartingScore = startingScore;
    }
}