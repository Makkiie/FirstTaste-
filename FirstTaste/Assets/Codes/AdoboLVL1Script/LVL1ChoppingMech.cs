using UnityEngine;
using UnityEngine.UI;

public class ChopItems : MonoBehaviour
{
    public Image refImage;        // Reference to the image displaying the clicked item
    public Image blankImage;      // Image to display before chopping
    public Image resultImage;     // Image to display after chopping
    public Sprite choppedPork;    // Chopped version of pork image
    public Sprite choppedGarlic;  // Chopped version of garlic image

    private void Start()
    {
        // Ensure the result image is off at start
        resultImage.gameObject.SetActive(false);
    }

    public void OnItemClicked(Sprite itemSprite)
    {
        // Display the clicked item in the reference image
        refImage.sprite = itemSprite;

        // Show the blank image (reset the chopping area)
        blankImage.gameObject.SetActive(true);
    }

    public void OnChopButtonPressed()
    {
        // Assuming that the refImage sprite can be checked
        if (refImage.sprite == choppedPork)
        {
            resultImage.sprite = choppedPork; // Set chopped result
        }
        else if (refImage.sprite == choppedGarlic)
        {
            resultImage.sprite = choppedGarlic; // Set chopped result
        }

        // Hide the blank image and show the result image
        blankImage.gameObject.SetActive(false);
        resultImage.gameObject.SetActive(true);
    }

    public void OnBackButtonPressed()
    {
        // Reset the UI elements when going back
        resultImage.gameObject.SetActive(false);
        blankImage.gameObject.SetActive(true); // Ensure chopping area is reset
    }
}
