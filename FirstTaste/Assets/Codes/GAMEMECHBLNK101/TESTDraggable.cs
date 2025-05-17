using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Transform originalParent;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(canvas.transform, true);  // Preserve world position
        canvasGroup.blocksRaycasts = false;
        Blank101Inventory previousSlot = originalParent.GetComponent<Blank101Inventory>();
        if (previousSlot != null)
        {
            previousSlot.ClearItem();
        }

        transform.SetParent(canvas.transform, true);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        bool droppedOnSlot = false;

        foreach (var result in results)
        {
            Blank101Inventory slot = result.gameObject.GetComponent<Blank101Inventory>();
            if (slot != null && slot.HasSpace())
            {
                slot.SetItem(gameObject);
                droppedOnSlot = true;
                break;
            }
        }

        if (!droppedOnSlot)
        {
            Transform table = GameObject.Find("TABLEIMAGEOpacity").transform;
            transform.SetParent(table, true);  // Preserve position
        }

        // Optional: Clamp item within screen/canvas bounds
    }
}
