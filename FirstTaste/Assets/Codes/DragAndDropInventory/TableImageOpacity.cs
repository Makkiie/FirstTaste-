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

            // 🔻 Capture original parent (cabinet slot)
            Transform cabinetSlot = droppedObject.transform.parent;

            // ✅ Move the item to the table
            droppedRect.SetParent(dropAreaRect, false);

            // ❌ Destroy the cabinet slot GameObject (remove from cabinet)
            if (cabinetSlot != null && cabinetSlot.name.Contains("ItemSlotinside"))
            {
                GameObject.Destroy(cabinetSlot.gameObject);
            }

            // 🧭 Update position based on pointer drop
            Vector2 localPoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                dropAreaRect, eventData.position, canvas.worldCamera, out localPoint);
            droppedRect.anchoredPosition = localPoint;

            droppedObject.transform.SetAsLastSibling();

            // 📝 Save the item drop position
            ChoppingSessionData.tableitemPosition = localPoint;

            // ✅ Store the moved item ID
            var choppingPointer = droppedObject.GetComponent<ChoppingPointer>();
            if (choppingPointer != null)
            {
                ChoppingSessionData.movedItemIDs.Add(choppingPointer.itemID);
            }
            else
            {
                Debug.LogWarning("Dropped item has no ChoppingPointer, cannot track moved itemID.");
            }

            Debug.Log("✅ Item dropped on table: " + droppedObject.name);
        }
    }
}
