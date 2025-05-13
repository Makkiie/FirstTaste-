using UnityEngine;
using UnityEngine.EventSystems;
public class TableFreeDropArea : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;

        // Ensure the dragged item has the DragItem component
        DragItem draggableItem = dropped.GetComponent<DragItem>();

        if (draggableItem != null)
        {
            // Use the originalParent from DragItem to set the parent to this drop area
            draggableItem.transform.SetParent(transform, true);

            // Optionally, snap the position of the dropped item (adjust as necessary)
            draggableItem.transform.localPosition = Vector3.zero;  // Reset position or adjust accordingly
        }
    }
}
