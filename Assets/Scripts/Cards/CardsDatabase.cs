using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CardsDatabase : ScriptableObject
{
    public Card[] Cards;

    [ContextMenu("Update ID's")]
    public void UpdateID()
    {
        for (int i = 0; i < Cards.Length; i++)
        {
            if (Cards[i].CardID != i)
                Cards[i].CardID = i;
        }
    }
    public void OnAfterDeserialize()
    {
        UpdateID();
    }
}
