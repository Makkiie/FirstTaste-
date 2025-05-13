using UnityEngine;
using UnityEngine.EventSystems;


public class inventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        // Ensure that the dropped object has the DragItem component
        DragItem draggableItem = dropped.GetComponent<DragItem>();

        if (draggableItem != null)
        {
            // Use the originalParent of the DragItem to reparent the dragged item
            draggableItem.transform.SetParent(transform, true);  // Set this slot as the parent

            // Snap the position of the dropped item (optional based on your needs)
            draggableItem.transform.localPosition = Vector3.zero;  // Or adjust as needed
        }

    }
}
