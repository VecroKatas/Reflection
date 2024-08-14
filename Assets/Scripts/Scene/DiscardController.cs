using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardController : MonoBehaviour
{
    public List<Card> DiscardedCards = new List<Card>();

    public void DiscardCard(Card card)
    {
        DiscardedCards.Add(card);
    }

    public void OnTriggerEnter(Collider other)
    {
        DiscardCard(other.gameObject.GetComponent<TableCard>().AttachedCard);
        Destroy(other.gameObject);
    }
}
