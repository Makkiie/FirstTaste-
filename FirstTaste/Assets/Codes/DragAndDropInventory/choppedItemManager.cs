using UnityEngine;
using System.Collections.Generic;
    [System.Serializable]
public class ChoppedItemVisual
{
    public string itemType;
    public Sprite choppedSprite;
}

public class ChoppedItemManager : MonoBehaviour
{
    public List<ChoppedItemVisual> choppedItems;

    public Sprite GetChoppedSprite(string itemType)
    {
        var item = choppedItems.Find(x => x.itemType == itemType);
        return item != null ? item.choppedSprite : null;
    }
}

