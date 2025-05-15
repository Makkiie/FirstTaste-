using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private GameObject currentItem;

    public void SetItem(GameObject newItem)
    {
        //if already had an item, unparent and clear it
        newItem.transform.SetParent(transform, false); // 'false' keeps it local
        RectTransform rt = newItem.GetComponent<RectTransform>();
        if (rt != null)
        {
            rt.anchoredPosition = Vector2.zero;
        }
        newItem.SetActive(true); // make sure it’s visible
    }
    public bool HasSpace()
    {
        return currentItem == null;
    }
    public void ClearItem()
    {
        currentItem = null;
    }
}


