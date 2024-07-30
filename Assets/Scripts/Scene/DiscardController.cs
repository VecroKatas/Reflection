using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardController : MonoBehaviour
{
    public List<ICard> DiscardedCards = new List<ICard>();

    public void DiscardCard(ICard card)
    {
        DiscardedCards.Add(card);
    }
}
