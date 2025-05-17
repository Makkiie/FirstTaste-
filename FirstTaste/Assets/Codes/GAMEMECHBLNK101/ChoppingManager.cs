using UnityEngine;
using UnityEngine.UI;

public class ChopUIManager : MonoBehaviour
{
    [Header("Chop UI Panels")]
    public GameObject choppingPanel;
    public GameObject resultPanel; //NEW panel that shows the score result

    [Header("Chop UI Components")]
    public Image kitchenImage;
    public Image resultImage;
    public Text resultText;

    [Header("Arrow Mechanic")]
    public RectTransform arrow;
    public RectTransform bar;
    public float speed = 300f;

    private bool isChopping = false;
    private bool movingRight = true;

    private IngredientData currentIngredient;
    private Image originalSlot;

    public void OpenChopUI(IngredientData data, Image source)
    {
        currentIngredient = data;
        originalSlot = source;

        kitchenImage.sprite = data.rawSprite;
        resultImage.gameObject.SetActive(false);
        resultText.text = "";

        choppingPanel.SetActive(true);
        resultPanel.SetActive(false); // hide result panel at start
        arrow.anchoredPosition = Vector2.zero;
        movingRight = true;
        isChopping = true;
    }

    void Update()
    {
        if (!isChopping) return;

        float step = speed * Time.deltaTime;
        arrow.anchoredPosition += (movingRight ? Vector2.right : Vector2.left) * step;

        float half = bar.rect.width / 2;
        if (arrow.anchoredPosition.x > half) movingRight = false;
        else if (arrow.anchoredPosition.x < -half) movingRight = true;
    }

    public void TapToCut()
    {
        isChopping = false;

        float x = (arrow.anchoredPosition.x + bar.rect.width / 2) / bar.rect.width;

        string score = "Bad";
        Color color = Color.red;

        if (x >= 0.45f && x <= 0.55f)
        {
            score = "Perfect";
            color = Color.green;
        }
        else if (Mathf.Abs(x - 0.5f) < 0.15f)
        {
            score = "Good";
            color = Color.yellow;
        }

        // Show result
        resultText.text = score;
        resultText.color = color;
        resultImage.sprite = currentIngredient.choppedSprite;

        resultPanel.SetActive(true);           //  show score panel
        resultImage.gameObject.SetActive(true); // show chopped image
    }
   
    public void BackToGame()
    {
        if (originalSlot != null && currentIngredient != null) //Return to game Kitchen
            originalSlot.sprite = currentIngredient.choppedSprite;

        choppingPanel.SetActive(false);
    }
}
