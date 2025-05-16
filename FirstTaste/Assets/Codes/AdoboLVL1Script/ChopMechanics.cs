using UnityEngine;
using UnityEngine.UI;

public class ChoppingMechanic : MonoBehaviour
{
    public RectTransform arrow;
    public RectTransform barRectTransform;
    public float speed = 300f;

    public Button tapButton;
    public Image resultPanel;
    public Text resultText;
    public Image choppedImage;
    public Image displayImageNeedToCut;

    private bool movingRight = true;
    private float minX, maxX;
    private string currentItemName;

    private Sprite currentChopSprite;

    private void Start()
    {
        tapButton.onClick.AddListener(OnTap);
        arrow.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (arrow.gameObject.activeSelf)
        {
            float move = speed * Time.deltaTime * (movingRight ? 1 : -1);
            arrow.anchoredPosition += new Vector2(move, 0);

            if (arrow.anchoredPosition.x >= maxX) movingRight = false;
            if (arrow.anchoredPosition.x <= minX) movingRight = true;
        }
    }

    public void StartChopping(string itemName, Sprite itemSprite)
    {
        currentItemName = itemName;
        currentChopSprite = itemSprite;
        displayImageNeedToCut.sprite = itemSprite;

        arrow.anchoredPosition = new Vector2(0, arrow.anchoredPosition.y);
        arrow.gameObject.SetActive(true);
        resultPanel.gameObject.SetActive(false);

        float halfWidth = barRectTransform.rect.width / 2f;
        minX = -halfWidth;
        maxX = halfWidth;
    }

    private void OnTap()
    {
        float pos = arrow.anchoredPosition.x;

        string result;
        if (Mathf.Abs(pos) < 10)
            result = "Perfect";
        else if (Mathf.Abs(pos) < 40)
            result = "Good";
        else
            result = "Bad";

        resultText.text = result;
        choppedImage.sprite = currentChopSprite;
        arrow.gameObject.SetActive(false);
        resultPanel.gameObject.SetActive(true);
    }
}
