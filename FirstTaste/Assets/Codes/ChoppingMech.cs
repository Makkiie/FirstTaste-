using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoppingMEch : MonoBehaviour

{
    [Header("UI References")]
    public RectTransform arrow;
    public RectTransform bar;
    public Button tapButton;
    public GameObject resultPanel;
    public Text resultText;
    public Button exitButton;

    [Header("Movement Settings")]
    public float speed = 500f;

    private bool movingRight = true;
    private bool isMoving= true;
    private float leftLimit;
    private float rightLimit;
    public Image itemDisplayImage;

    private void Start()
    {
        string itemType = ChoppingSessionData.itemType;
        float barWidth = bar.rect.width;
        leftLimit = bar.localPosition.x - barWidth / 2f + 5F;
        rightLimit = bar.localPosition.x + barWidth / 2f - 5f;

        //handle tap button
        if (tapButton != null)
            tapButton.onClick.AddListener(Ontap);
        else
            UnityEngine.Debug.Log("Tap Button not assign");
        if (exitButton != null)
            exitButton.onClick.AddListener(HideResultPanel);
        if (resultPanel != null)
        {
            resultPanel.SetActive(false);
        }
        if(itemDisplayImage != null && ChoppingSessionData.originalSprite != null)
        {
            itemDisplayImage.sprite = ChoppingSessionData.originalSprite;
        }
    }

    private void Update()
    {
        if (!isMoving) return;

        Vector3 pos = arrow.localPosition;
        pos.x += (movingRight ? 1 : -1) * speed * Time.deltaTime;
        arrow.localPosition = pos;

        if (pos.x >= rightLimit)
            movingRight = false;
        else if (pos.x <= leftLimit)
            movingRight = true;
    }
    void Ontap()
    {
        isMoving = false;
        float arrowX = arrow.localPosition.x;
        float barWidth = bar.rect.width;

        float distanceFromLeft = arrowX - bar.localPosition.x + (barWidth / 2f);
        float percent = distanceFromLeft / barWidth;

        //Debug 
       
        if (percent >= 0.44f && percent <= 0.55f)
        {
            
            resultText.text = "Perfect!";
            resultText.color = Color.green;
        }
        else if (percent >= 0.30f && percent <= 0.65f)
        {
            resultText.text = "Good!";
            resultText.color = Color.yellow;
        }    
        else
        {
            resultText.text = "Bad!";
            resultText.color = Color.red;
        }
        resultPanel.SetActive(true);
        UnityEngine.Debug.Log($"Arrow Landed at {percent * 100f}% of The bar");
    }
    void HideResultPanel()
    { 
       resultPanel.SetActive(false);
        isMoving = true;
        resultText.text = "";
    }
    void ExitChoppingScene()
    {
        SceneManager.LoadScene("");
    }
}

