using UnityEngine;
using UnityEngine.EventSystems;


public class inventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DragItem  draggableItem = dropped.GetComponent<DragItem>();
        draggableItem.parentsAfterDrag = transform;

    }
}
