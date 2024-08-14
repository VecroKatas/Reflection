using System;
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

    public void OnTriggerEnter(Collider other)
    {
        DiscardCard(other.gameObject.GetComponent<TableCard>().AttachedCard);
        Destroy(other.gameObject);
    }
}
