using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
//, IBeginDragHandler, IEndDragHandler, IDragHandler
public class HandController : MonoBehaviour
{
    [SerializeField] private DeckController _deckController;
    [SerializeField] private TableController _tableController;
    [SerializeField] private DiscardController _discardController;
    
    [SerializeField] private GameObject HandCard;
    public int MaxHandSize = 10;
    public List<Card> Cards = new List<Card>();
    public List<HandCardController> HandCards = new List<HandCardController>();

    public void CheckHand()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            HandCardController handCardController = transform.GetChild(i).GetComponent<HandCardController>();
            if (!HandCards.Contains(handCardController))
                HandCards.Add(handCardController);
        }
    }

    public void DrawCards([CanBeNull] List<Card> cardsToDraw)
    {
        while (Cards.Count < MaxHandSize)
        {
            Card drawnCard;
            if (cardsToDraw.Count > 0) // does it work?
            {
                drawnCard = _deckController.DrawCard(cardsToDraw[0]);
                cardsToDraw.RemoveAt(0);
            }
            else
                drawnCard = _deckController.DrawCard();

            Cards.Add(drawnCard);

            CreateCardInHand(drawnCard);
        }
    }

    private void CreateCardInHand(Card card)
    {
        GameObject cardInHand = Instantiate(HandCard, Vector3.zero, Quaternion.identity);
        cardInHand.GetComponent<HandCardController>().AttachedCard = card;
        cardInHand.transform.SetParent(transform);
    }

    public void PlayCard(HandCardController handCard)
    {
        _tableController.PlayCard(handCard.AttachedCard);

        DeleteHandCard(handCard);
    }

    public void DiscardAllCards()
    {
        CheckHand();

        while (HandCards.Count > 0)
        {
            _discardController.DiscardCard(HandCards[0].AttachedCard);
            DeleteHandCard(HandCards[0]);
        }
    }

    private void DeleteHandCard(HandCardController handCard)
    {
        HandCards.Remove(handCard);
        Cards.Remove(handCard.AttachedCard);
        Destroy(handCard.gameObject);
    }
    
    
    
    
    public void OnDragStart(GameObject obj)
    {
        MouseData.tempCard = CreateTempItem(obj);
    }
    public GameObject CreateTempItem(GameObject obj)
    {
        GameObject tempLocalCard = null;
        if(obj.GetComponent<HandCardController>().AttachedCard.CardID >= 0)
        {
            
        }
        return tempLocalCard;
    }
    public void OnDragEnd(HandCardController handCardController)
    {
        Destroy(MouseData.tempCard);
        if (MouseData.hoveredOver.name == "Table")
        {
            PlayCard(handCardController);
        }
    }
    public void OnDrag(GameObject obj)
    {
        if (MouseData.tempCard != null)
            MouseData.tempCard.GetComponent<RectTransform>().position = Input.mousePosition;
    }
}

public static class MouseData
{
    public static GameObject tempCard;
    public static GameObject hoveredOver;
}