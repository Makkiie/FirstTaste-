using UnityEngine;

public class Blank101FridgeControlle : MonoBehaviour
{
    public GameObject fridgePanel; 
    public void ToggleFridge()
    {
        fridgePanel.SetActive(!fridgePanel.activeSelf);
    }
}
