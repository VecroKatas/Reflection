using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TableCard : MonoBehaviour
{
    public ICard AttachedCard;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardDescription;
    [SerializeField] private Image image;

    private void Start()
    {
        cardName.text = AttachedCard.Name;
        cardDescription.text = AttachedCard.Description;
    }
}
