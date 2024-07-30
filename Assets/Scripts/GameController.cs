using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private HandController _handController;
    
    public List<ICard> CardsToDraw = new List<ICard>();
    
    private void Start()
    {
        //some initialization
        
        StartNextTurn();
    }

    public void StartNextTurn()
    {
        _handController.DiscardAllCards();
        
        _handController.DrawCards(CardsToDraw);
        
        
    }
}
