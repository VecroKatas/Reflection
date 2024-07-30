using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class HandController : MonoBehaviour
{
    [SerializeField] private static GameObject HandCard;
    [SerializeField] private static GameObject CardOnTable;
    public static int MaxHandSize = 10;
    public static List<ICard> Cards = new List<ICard>();
    public static List<HandCardController> HandCards = new List<HandCardController>();

    public static void DrawCards([CanBeNull] List<ICard> cardsToDraw)
    {
        if (cardsToDraw != null)
            cardsToDraw.ForEach(c => Cards.Add(c));

        while (Cards.Count < MaxHandSize)
        {
            ICard drawnCard;
            if (Cards.Count > 0)
            {
                drawnCard = DeckController.DrawCard(Cards[0]);
                Cards.RemoveAt(0);
            }
            else
                drawnCard = DeckController.DrawCard();

            Cards.Add(drawnCard);

            CreateCardInHand(drawnCard); 
        }
    }

    private static void CreateCardInHand(ICard card)
    {
        GameObject cardInHand = Instantiate(HandCard, Vector3.zero, Quaternion.identity);
        //cardInHand.transform.SetParent();
    }

    /*public void PlayCard(HandCard handCard)
    {
        TableController.PLayCard(handCard.ICard);

        DeleteHandCard();
    }*/

    public static void DiscardAllCards()
    {
        
    }
    
    
    
    
    
    private HandController() { }

    private static HandController _instance;
    
    private static readonly object _lock = new object();

    public static HandController GetInstance()
    {
        if (_instance == null)
            lock (_lock)
                if (_instance == null)
                {
                    _instance = new HandController();
                }

        return _instance;
    }
}
