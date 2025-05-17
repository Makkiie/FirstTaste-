using UnityEngine;
using UnityEngine.UI;

public class CuttingManager : MonoBehaviour
{
    public GameObject cuttingPanel;
    public Image kitchenImage; // Shows meat to cut
    public GameObject resultPanel;
    public Image resultImage; // Shows result sprite
    public Sprite choppedMeatSprite; // Assign this in Inspector
    private Image sourceSlotImage; // The UI slot where the meat came from

    public void OpenCutting(Sprite sourceSprite, Image sourceImage)
    {
        sourceSlotImage = sourceImage;
        kitchenImage.sprite = sourceSprite;
        kitchenImage.preserveAspect = true;

        cuttingPanel.SetActive(true);
        resultPanel.SetActive(false);
    }

    public void OnTapToCut()
    {
        resultPanel.SetActive(true);
        resultImage.sprite = choppedMeatSprite;
        resultImage.preserveAspect = true;
    }

    public void OnBack()
    {
        cuttingPanel.SetActive(false);
        if (sourceSlotImage != null)
            sourceSlotImage.sprite = choppedMeatSprite;
    }
}
