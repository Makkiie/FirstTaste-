using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NeedleController : MonoBehaviour
{
    public RectTransform needle;
    public float rotationSpeed = 180f;
    private float currentAngle = 0f;
    private bool rotating = true;

    [Header("UI")]
    public GameObject resultPanel;
    public TMP_Text resultText;

    void Update()
    {
        if (rotating)
        {
            currentAngle += rotationSpeed * Time.deltaTime;

            if (currentAngle >= 360f)
            {
                currentAngle = 360f;
                rotating = false;
                EvaluateResult(currentAngle); // Auto stop at full circle
                return;
            }

            needle.localRotation = Quaternion.Euler(0, 0, -currentAngle);
        }
    }

    public void StopNeedle()
    {
        if (!rotating) return;

        rotating = false;
        EvaluateResult(currentAngle);
    }

    void EvaluateResult(float angle)
    {
        float adjustedAngle = (angle + 90f) % 360f;

        Debug.Log($"[DEBUG] Needle Landed at Raw Angle: {angle}, Adjusted Angle: {adjustedAngle}");

        if (adjustedAngle >= 121f && adjustedAngle <= 160f) // green
        {
            resultText.text = "Perfect!";
            resultText.color = Color.green;
        }
        else if ((adjustedAngle >= 91f && adjustedAngle < 121f) || (adjustedAngle > 160f && adjustedAngle <= 180f)) // yellow
        {
            resultText.text = "Good!";
            resultText.color = Color.yellow;
        }
        else // red
        {
            resultText.text = "Bad!";
            resultText.color = Color.red;
        }

        resultPanel.SetActive(true);
    }

    void ShowResult(string message, Color color)
    {
        resultText.text = message;
        resultText.color = color;
        resultPanel.SetActive(true);
    }

    public void CloseResult()
    {
        resultPanel.SetActive(false);
        rotating = true;
        currentAngle = 0f;
    }

    public void ResetGame()
    {
        rotating = true;
        currentAngle = 0f;
        resultPanel.SetActive(false);
        needle.rotation = Quaternion.Euler(0f, 0f, 0f);
        Debug.Log("[DEBUG] Game Reset");
    }
}
