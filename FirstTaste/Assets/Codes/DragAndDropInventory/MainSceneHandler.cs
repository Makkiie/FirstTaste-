using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public GameObject itemPrefab;

    private GameObject currentItem;

    private void Start()
    {
        GameObject tableObj = GameObject.Find("TABLEIMAGEOpacity");
        if (tableObj == null)
        {
            Debug.LogError("❌ TABLEIMAGEOpacity GameObject not found in main scene.");
            return;
        }

        // Check if an item is already present on the table
        bool itemExists = false;
        foreach (Transform child in tableObj.transform)
        {
            if (child.gameObject.name.Contains(itemPrefab.name)) // Or any other identification logic
            {
                itemExists = true;
                currentItem = child.gameObject;
                break;
            }
        }

        // Instantiate only if not already on the table
        if (!itemExists && ChoppingSessionData.tableitemPosition.HasValue && itemPrefab != null)
        {
            currentItem = Instantiate(itemPrefab);
            currentItem.transform.SetParent(tableObj.transform, false);
            RectTransform itemRectTransform = currentItem.GetComponent<RectTransform>();
            itemRectTransform.anchoredPosition = ChoppingSessionData.tableitemPosition.Value;

            Debug.Log("✅ Restored item position at: " + ChoppingSessionData.tableitemPosition.Value);
        }
        else if (itemExists)
        {
            Debug.Log("Item already exists on the table, skipping instantiation.");
        }
        else
        {
            Debug.Log("No stored item position or itemPrefab not assigned.");
        }
    }
}
