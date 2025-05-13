using NUnit.Framework.Constraints;
using UnityEngine;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<DragItem> allItems; // Assign these in Inspector
    public ChoppedItemManager choppedItemManager;
    public void Start()
    {
       if (!string.IsNullOrEmpty(ChoppingSessionData.result))
            {
            DragItem item = allItems.Find(x => x.itemID == ChoppingSessionData.itemID);
            if (item != null)
            {
                Sprite choppedSprite = choppedItemManager.GetChoppedSprite(ChoppingSessionData.itemType);
                if (choppedSprite != null)
                {
                    item.image.sprite = choppedSprite;
                   
                }
                // Optionally store result for scoring
                Debug.Log("Chop result: " + ChoppingSessionData.result);
            }
            }
       ChoppingSessionData.result = null;
        }
    }

