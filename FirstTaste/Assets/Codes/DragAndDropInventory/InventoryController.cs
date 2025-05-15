using UnityEngine;
using System.Collections;

public class InventoryController : MonoBehaviour
{
    public GameObject fridgePanel;
    public ChoppedItemManager choppedItemManager;


    private void Awake()
    {
        Debug.Log("InventoryController Awake");
    }
    private void OnEnable()
    {
        Debug.Log("📦 InventoryController OnEnable called!");
        StartCoroutine(UpdateChoppedAfterFrame());
    }

    private IEnumerator UpdateChoppedAfterFrame()
    {
        // Wait 2 frames to ensure UI is ready
        yield return null;
        yield return null;

        ChoppingPointer[] foundItems = FindObjectsOfType<ChoppingPointer>(includeInactive: true);
        Debug.Log($"🧩 Total ChoppingPointers found: {foundItems.Length}");
        Debug.Log($"🔍 Looking for itemID: '{ChoppingSessionData.itemID}'");

        foreach (var item in foundItems)
        {
            string imageStatus = item.image == null ? "NULL" : "VALID";
            Debug.Log($"🧾 Found item: {item.name}, itemID: '{item.itemID}', Image: {imageStatus}, Parent: {item.transform.parent.name}");
        }

        var match = System.Array.Find(foundItems, x => x.itemID == ChoppingSessionData.itemID);
        if (match != null)
        {
            Debug.Log("✅ MATCH FOUND: " + match.itemID);

            if (ChoppingSessionData.choppedSprite != null)
            {
                match.image.sprite = ChoppingSessionData.choppedSprite;
                match.chopResult = ChoppingSessionData.result;

                match.image.enabled = false;
                match.image.enabled = true;

                Debug.Log("✅ Chopped sprite applied and UI refreshed for: " + match.itemID);

                GameObject tableObj = GameObject.Find("TABLEIMAGEOpacity");
                if (tableObj != null)
                {
                    Transform table = tableObj.transform;
                    match.transform.SetParent(table, false);

                    RectTransform matchRect = match.GetComponent<RectTransform>();

                    // ✅ Restore previous position if available
                    if (ChoppingSessionData.previousPosition.HasValue)
                    {
                        matchRect.anchoredPosition = ChoppingSessionData.previousPosition.Value;
                    }
                    else
                    {
                        matchRect.anchoredPosition = Vector2.zero;
                    }

                    match.transform.SetAsLastSibling();
                    Debug.Log("✅ Item moved to TABLEIMAGEOpacity: " + match.itemID);
                }
                else
                {
                    Debug.LogError("❌ TABLEIMAGEOpacity not found!");
                }
            }
        }
        else
        {
            Debug.LogError("❌ No item with itemID: '" + ChoppingSessionData.itemID + "' found in scene.");
        }

        // Clear session data
        ChoppingSessionData.itemID = null;
        ChoppingSessionData.itemType = null;
        ChoppingSessionData.result = null;
        ChoppingSessionData.originalSprite = null;
        ChoppingSessionData.choppedSprite = null;
    }

    public void ToggleFridge()
    {
        fridgePanel.SetActive(!fridgePanel.activeSelf);
    }
}
