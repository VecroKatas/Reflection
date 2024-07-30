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
        //draw predetermined card, do needed calculations maybe?
        return null;
    }

    private ICard GetCard()
    {
        // some calculations instead i guess
        return _cardsDatabase.Cards[_random.Next(_cardsDatabase.Cards.Length)];
    }
}
