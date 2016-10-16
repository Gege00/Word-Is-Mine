using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class OnPointerClick : MonoBehaviour, IPointerClickHandler, IScrollHandler {
    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log("Scroll");
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        
        Debug.Log("Clicked!");
    }
}
