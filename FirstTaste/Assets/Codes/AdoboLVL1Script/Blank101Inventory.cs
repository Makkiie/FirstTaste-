using UnityEngine;
using static UnityEditor.Progress;

public class Blank101Inventory : MonoBehaviour
{
    private GameObject currentItem;

    public bool HasSpace()
    {
        return currentItem == null;
    }


    public void SetItem(GameObject item)
    {
        //if already had an item, unparent and clear it
        if(currentItem != null)
        {
            currentItem.transform.SetParent(null);
        }
        item.transform.SetParent(transform, false);
        item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
    }
  
    public void ClearItem()
    {
        currentItem = null;
    }

}
