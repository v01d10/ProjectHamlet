using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{
    [SerializeField]private RectTransform DragRectTransform;
    public Canvas Canvas;

    public void OnDrag(PointerEventData eventData)
    {
        DragRectTransform.anchoredPosition += eventData.delta / Canvas.scaleFactor;
    }
}
