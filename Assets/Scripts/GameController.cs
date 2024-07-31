using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private HandController _handController;
    [SerializeField] private int StartingTurn = 48;
    [SerializeField] private int FinalTurn = 100;
    
    public int CurrentYear => CurrentTurn / 4;
    public int CurrentSeason => CurrentTurn % 4;

    public int CurrentTurn;
    public List<ICard> CardsToDraw = new List<ICard>();

    private void Start()
    {
        //some initialization
        CurrentTurn = StartingTurn;
        StartNextTurn();
    }

    public void StartNextTurn()
    {
        CurrentTurn++;
        
        _handController.DiscardAllCards();
        
        _handController.DrawCards(CardsToDraw);
               
    }
}
