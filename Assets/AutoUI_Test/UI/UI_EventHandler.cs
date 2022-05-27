using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    public Action<PointerEventData> OnClickHandler = null;
    public Action<PointerEventData> OnDragHandler = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("CLICKED!!");
        if (OnClickHandler != null)
        {
            OnClickHandler.Invoke(eventData); // 努腐客 包访等 咀记 角青
        }
            
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DRAGED~~");
        if (OnDragHandler != null)
        {
            OnDragHandler.Invoke(eventData); // 靛贰弊客 包访等 咀记 角青
        }
    }
}
