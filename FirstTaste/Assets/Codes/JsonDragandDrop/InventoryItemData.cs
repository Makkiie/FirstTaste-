using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [System.Serializable]
    public class InventoryItemData
    {
        public string itemID;
        public string itemName;
        public string iconPath; // optional: path to sprite/icon if needed
    }
}
