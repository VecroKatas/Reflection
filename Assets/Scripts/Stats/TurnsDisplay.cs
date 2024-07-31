using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnsDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yearCounter;
    [SerializeField] private TextMeshProUGUI turnCounter;
    [SerializeField] private GameController _gameController;

    public void RefreshTurnDisplay()
    {
        yearCounter.text = _gameController.CurrentYear.ToString();

        string season;
        switch (_gameController.CurrentSeason)
        {
            case 0: season = "Spring"; break;
            case 1: season = "Summer"; break;
            case 2: season = "Autumn"; break;
            case 3: season = "Winter"; break;
            default: season = "Default"; break;
        }
        turnCounter.text = season;
    }

    // remake with delegates and subscription to events
    private void FixedUpdate()
    {
        RefreshTurnDisplay();
    }
}