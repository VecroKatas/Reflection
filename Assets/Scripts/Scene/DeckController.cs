using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    
    public ICard DrawCard()
    {
        // calculate card to draw
        return null;
    }
    
    public ICard DrawCard([CanBeNull] ICard cardToDraw)
    {
        //draw predetermined card, do some calculations maybe?
        return null;
    }
}
