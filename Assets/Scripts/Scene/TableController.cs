using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private GameObject tableCard;
    public List<ICard> CardsOnTable = new List<ICard>();
    public Camera targetCamera;

    public void PlayCard(ICard card)
    {
        CardsOnTable.Add(card);
        card.Play();
       
        GameObject playedCard = Instantiate(tableCard, targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.5f)), Quaternion.identity);
        playedCard.GetComponent<TableCard>().AttachedCard = card;
        playedCard.transform.SetParent(transform);
        
        
        //idfk for now  
    }
}
