using UnityEngine;
using UnityEngine.UI;

public class ToggleButtonImage : MonoBehaviour
{
    public Button button;            // Assign your button
    public Sprite defaultSprite;     // Sprite to show normally
    public Sprite clickedSprite;     // Sprite to show when clicked

    private Image buttonImage;
    private bool isClicked = false;

    void Start()
    {
        buttonImage = button.GetComponent<Image>();
        buttonImage.sprite = defaultSprite; // Set to default initially

        button.onClick.AddListener(ToggleImage);
    }

    void ToggleImage()
    {
        isClicked = !isClicked;

        if (isClicked)
        {
            buttonImage.sprite = clickedSprite;
        }
        else
        {
            buttonImage.sprite = defaultSprite;
        }
    }
}
