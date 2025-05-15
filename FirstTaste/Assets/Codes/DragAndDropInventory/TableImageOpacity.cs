using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UniversalDropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;

        if (droppedObject != null)
        {
            RectTransform dropAreaRect = GetComponent<RectTransform>();
            RectTransform droppedRect = droppedObject.GetComponent<RectTransform>();
            Canvas canvas = GetComponentInParent<Canvas>();

            // Reparent to table UI
            droppedRect.SetParent(dropAreaRect, false);

            // Convert screen point to local point in table RectTransform
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                dropAreaRect, eventData.position, canvas.worldCamera, out localPoint);

            droppedRect.anchoredPosition = localPoint;
            droppedObject.transform.SetAsLastSibling();

            Debug.Log("✅ Item dropped on table: " + droppedObject.name);
        }
    }
}
