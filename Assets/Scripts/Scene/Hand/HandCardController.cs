using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandCardController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardDescription;
    [SerializeField] private Image image;
    [SerializeField] private Vector3 minSize;
    [SerializeField] private Vector3 maxSize;

    public ICard AttachedCard;
    
    private bool scaleUpEnded = false;
    private bool pointerExited = true;
    private static bool beingDragged = false;

    private GameObject clone;
    private RectTransform rt;
    private float mouseY;

    private void Start()
    {
        //cardName.text = AttachedCard.Name;
        //cardDescription.text = AttachedCard.Description;
    }

    public void PointerEnter()
    {
        if (!beingDragged)
        {
            pointerExited = false;
            StartCoroutine(ScaleUp());
        }
    }

    public void PointerExit()
    {
        if (!beingDragged)
        {
            pointerExited = true;
            if (scaleUpEnded)
                StartCoroutine(ScaleDown());
        }
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
    public void OnBeginDrag(PointerEventData eventData)
    {
        StartCoroutine(ScaleDown());
        beingDragged = true;
        
        clone = Instantiate(gameObject, transform.localPosition, Quaternion.identity);
        clone.GetComponent<HandCardController>().AttachedCard = AttachedCard;
        clone.transform.SetParent(transform.parent);
        rt = clone.GetComponent<RectTransform>();
        rt.localScale = maxSize;
        rt.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y + rectTransform.parent.GetComponent<RectTransform>().sizeDelta.y);
        mouseY = rectTransform.anchoredPosition.y + rectTransform.parent.GetComponent<RectTransform>().sizeDelta.y;
        
        rt.gameObject.GetComponent<LayoutElement>().ignoreLayout = true;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rt.anchoredPosition += eventData.delta;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        beingDragged = false;
        rt.gameObject.GetComponent<LayoutElement>().ignoreLayout = false;
        if (rt.anchoredPosition.y > mouseY + rectTransform.parent.GetComponent<RectTransform>().sizeDelta.y)
            transform.parent.GetComponent<HandController>().PlayCard(this);
        Destroy(clone);
        rt = null;
    }
}
