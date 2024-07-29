using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandCardController : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardDescription;
    [SerializeField] private Image image;
    [SerializeField] private Vector3 minSize;
    [SerializeField] private Vector3 maxSize;

    //public ICard AttachedCard;
    public EventCard AttachedCard;
    
    private bool scaleUpEnded = false;
    private bool pointerExited = true;

    private void Start()
    {
        cardName.text = AttachedCard.Name;
        cardDescription.text = AttachedCard.Description;
    }

    public void PointerEnter()
    {
        pointerExited = false;
        StartCoroutine(ScaleUp());
    }

    public void PointerExit()
    {
        pointerExited = true;
        if (scaleUpEnded)
            StartCoroutine(ScaleDown());
    }
    
    IEnumerator ScaleUp()
    {
        scaleUpEnded = false;
        
        for (float i = 0; i <= .25; i += Time.deltaTime)
        {
            rectTransform.localScale = Vector3.Lerp(minSize, maxSize, EaseIn(i * 4));
            
            yield return null;
        }

        if (pointerExited)
            StartCoroutine(ScaleDown());
        
        scaleUpEnded = true;
    }
    
    IEnumerator ScaleDown()
    {
        for (float i = 0; i <= .25; i += Time.deltaTime)
        {
            rectTransform.localScale = Vector3.Lerp(maxSize, minSize, EaseOut(i * 4));
        
            yield return null;
        }
    }

    private float EaseOut(float i)
    {
        return (float) (1 - Math.Cos((i * Math.PI) / 2));
    }
    
    private float EaseIn(float i)
    {
        return (float)Math.Sin((i * Math.PI) / 2);
    }
}
