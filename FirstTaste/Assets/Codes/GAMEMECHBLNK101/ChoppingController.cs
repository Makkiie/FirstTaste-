using UnityEngine;
using UnityEngine.UI;

public class ChoppingController : MonoBehaviour
{
    public Image kitchenImage;
    public Image resultImage;
    public GameObject cuttingPanel;

    private Image originalItemImage;
    private IngredientData currentIngredient;

    public void StartChopping(Image itemImage, IngredientData ingredient)
    {
        originalItemImage = itemImage;
        currentIngredient = ingredient;

        kitchenImage.sprite = ingredient.rawSprite;
        resultImage.sprite = null;
        resultImage.gameObject.SetActive(false);

        cuttingPanel.SetActive(true);
    }

    public void TapToCut()
    {
        if (currentIngredient != null)
        {
            resultImage.sprite = currentIngredient.choppedSprite;
            resultImage.gameObject.SetActive(true);
        }
    }

    public void BackToGame()
    {
        if (originalItemImage != null && currentIngredient != null)
        {
            originalItemImage.sprite = currentIngredient.choppedSprite;
        }
        cuttingPanel.SetActive(false);
    }
}
