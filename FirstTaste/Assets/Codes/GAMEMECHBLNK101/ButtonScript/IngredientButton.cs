using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    public IngredientData ingredientData; // Drag the ScriptableObject here
    public ChopUIManager chopUIManager;   // Drag the manager that controls cutting

    private Image thisImage;

    void Start()
    {
        thisImage = GetComponent<Image>();
        if (ingredientData != null)
            thisImage.sprite = ingredientData.rawSprite;
    }

    public void OnClickItem()
    {
        chopUIManager.OpenChopUI(ingredientData, thisImage);
    }
}
