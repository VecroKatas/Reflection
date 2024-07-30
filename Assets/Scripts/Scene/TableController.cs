using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    public List<ICard> CardsOnTable = new List<ICard>();

    public void PlayCard(ICard card)
    {
        CardsOnTable.Add(card);
        //idfk for now  
    }
}
