using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(canvas.transform, true); // Keep world position
        canvasGroup.blocksRaycasts = false;

        // If original parent is an InventorySlot, clear it
        var previousSlot = originalParent.GetComponent<InventorySlot>();
        if (previousSlot != null)
        {
            previousSlot.ClearItem();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        bool droppedOnSlot = false;

        foreach (var result in results)
        {
            InventorySlot slot = result.gameObject.GetComponent<InventorySlot>();
            if (slot != null && slot.HasSpace())
            {
                slot.SetItem(gameObject);
                droppedOnSlot = true;
                break;
            }
        }

        if (!droppedOnSlot)
        {
            // Drop on TABLEIMAGEOpacity
            GameObject tableObj = GameObject.Find("TABLEIMAGEOpacity");
            if (tableObj != null)
            {
                Transform table = tableObj.transform;
                transform.SetParent(table, false); // keep local position

                // Convert screen position to local anchored position inside table
                RectTransform tableRect = table.GetComponent<RectTransform>();
                Vector2 localPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    tableRect, eventData.position, canvas.worldCamera, out localPoint);
                rectTransform.anchoredPosition = localPoint;

                transform.SetAsLastSibling(); // Render on top
                Debug.Log("✅ Dropped item on table: " + gameObject.name);
            }
            else
            {
                Debug.LogError("❌ TABLEIMAGEOpacity object not found!");
                transform.SetParent(originalParent, false); // fallback
            }
        }
    }
}
