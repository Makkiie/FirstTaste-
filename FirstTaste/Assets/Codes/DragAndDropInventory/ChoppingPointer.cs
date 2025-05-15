using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoppingPointer : MonoBehaviour, IPointerClickHandler
{
    public string itemID;       // ✅ Unique per item instance
    public string itemType;     // ✅ General type like "Pork", "Garlic"
    public Image image;
    public string chopResult;  // ✅ This will store "Perfect", "Good", or "Bad"

    public void OnPointerClick(PointerEventData eventData)
    {
        // Store selected item data
        ChoppingSessionData.itemID = itemID;
        ChoppingSessionData.itemType = itemType;
        ChoppingSessionData.originalSprite = image.sprite;

        // ✅ Store position before scene change
        RectTransform rect = GetComponent<RectTransform>();
        ChoppingSessionData.previousPosition = rect.anchoredPosition;


        // Load Chopping Scene
        SceneManager.LoadScene("ChoppingScene");
    }
}
