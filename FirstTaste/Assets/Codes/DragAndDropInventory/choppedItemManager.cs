using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChoppedItemVisual
{
    public string itemType; // e.g., "Meat", "Garlic"
    public Sprite choppedSprite;
}

public class ChoppedItemManager : MonoBehaviour
{
    public List<ChoppedItemVisual> choppedItems;

    public Sprite GetChoppedSprite(string itemType)
    {
        var data = choppedItems.Find(x => x.itemType == itemType);
        return data != null ? data.choppedSprite : null;
    }
}
