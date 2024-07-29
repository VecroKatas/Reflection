using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<ICard> CardsToDraw = new List<ICard>();
    
    private void Start()
    {
        //some initialization
        
        StartNextTurn();
    }

    public void StartNextTurn()
    {
        HandController.DiscardAllCards();
        
        HandController.DrawCards(CardsToDraw);
        
        
    }
    
    
    
    private GameController() { }

    private static GameController _instance;
    
    private static readonly object _lock = new object();

    public static GameController GetInstance()
    {
        if (_instance == null)
            lock (_lock)
                if (_instance == null)
                {
                    _instance = new GameController();
                }

        return _instance;
    }
}
