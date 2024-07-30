using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    
    public static ICard DrawCard()
    {
        // calculate card to draw
        return null;
    }
    
    public static ICard DrawCard([CanBeNull] ICard cardToDraw)
    {
        //draw predetermined card
        return null;
    }
    
    
    
    
    
    private DeckController() { }

    private static DeckController _instance;
    
    private static readonly object _lock = new object();

    public static DeckController GetInstance()
    {
        if (_instance == null)
            lock (_lock)
                if (_instance == null)
                {
                    _instance = new DeckController();
                }

        return _instance;
    }
}
