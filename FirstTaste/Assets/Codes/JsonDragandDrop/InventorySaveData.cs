using UnityEngine;
using System.Collections.Generic;
using static NewMonoBehaviourScript;

public class InventorySaveData : MonoBehaviour
{
    [System.Serializable]
    public class inventorySaveData
    {
        public List<InventoryItemData> items = new List<InventoryItemData>();
    }
}
