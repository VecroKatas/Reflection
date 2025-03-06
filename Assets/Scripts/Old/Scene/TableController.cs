using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private GameObject tableCard;
    public List<Card> CardsOnTable = new List<Card>();
    public Camera targetCamera;

    public void PlayCard(Card card)
    {
        CardsOnTable.Add(card);
        card.Play();
        
        GameObject playedCard = Instantiate(tableCard, targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.5f)), Quaternion.identity);
        playedCard.GetComponent<TableCard>().AttachedCard = card;
        playedCard.transform.SetParent(transform);
        
        
        CardsOnTable.ForEach(c => Debug.Log(c));
        //idfk for now  
    }
}
