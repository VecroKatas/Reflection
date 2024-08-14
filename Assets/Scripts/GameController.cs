using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private HandController _handController;
    [SerializeField] private int StartingTurn = 48;
    [SerializeField] private int FinalTurn = 100;

    [SerializeField] private TextMeshProUGUI gameEnd;
    
    public int CurrentYear => CurrentTurn / 4;
    public int CurrentSeason => CurrentTurn % 4;

    public int CurrentTurn;
    public List<Card> CardsToDraw = new List<Card>();

    private void Start()
    {
        //some initialization
        CurrentTurn = StartingTurn;
        //StartNextTurn();
    }

    public void StartNextTurn()
    {
        CurrentTurn++;
        
        if (CurrentTurn == 100)
            GameEnd();
        _handController.DiscardAllCards();
        
        _handController.DrawCards(CardsToDraw);
               
    }

    public void GameEnd()
    {
        if (CurrentTurn == 100)
            gameEnd.text = "Yay you won";
        else
            gameEnd.text = "Damn you lost. Some of your status cards went to an extreme and you most likely lost. But it was Satisfaction, you won, you little Congratulations steak";
    }
}
