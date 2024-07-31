using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;

public class DeckController : MonoBehaviour
{
    [SerializeField] private CardsDatabase _cardsDatabase;

    private Random _random = new System.Random();
    
    public ICard DrawCard()
    {
        // calculate card to draw
        return GetCard();
    }
    
    public ICard DrawCard([CanBeNull] ICard cardToDraw)
    {
        //draw predetermined card by another card, do needed calculations maybe?
        return null;
    }

    private ICard GetCard()
    {
        int Length = _cardsDatabase.Cards.Length;
        int[] RelevanceValues = new int[Length];
        int OverallValue = 0;
        for (int i = 0; i < Length; i++)
        {
            RelevanceValues[i] = _cardsDatabase.Cards[i].Relevance();
            OverallValue += RelevanceValues[i];
        }

        int AdddedValue = 0;
        int Determinator = _random.Next(0, OverallValue);
        for (int i = 0; i < Length; i++)
        {
            if (RelevanceValues[i] + AdddedValue >= Determinator)
                return _cardsDatabase.Cards[i];
            AdddedValue += RelevanceValues[i];
        }
        return null; // it shouldn`t reach this line ever
    }

    void OnApplicationQuit()
    {
        foreach (ICard card in _cardsDatabase.Cards)
            card.HasBeenPlayed = true;
    }
}
