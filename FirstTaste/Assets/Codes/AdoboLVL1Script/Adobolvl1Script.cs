using UnityEngine;
using UnityEngine.UI;

public class AdoboLevel1Script : MonoBehaviour
{
    public GameObject refrigerator;
    public GameObject knife;
    public GameObject resultPanel;
    public Image choppedImage; // Image to display the chopped result
    private bool isRefrigeratorOpen = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CheckForInteraction(mousePos);
        }
    }

    void CheckForInteraction(Vector2 position)
    {
        // Check if the refrigerator is clicked
        if (RectTransformUtility.RectangleContainsScreenPoint(refrigerator.GetComponent<RectTransform>(), position))
        {
            OpenRefrigerator();
        }
        else if (isRefrigeratorOpen && RectTransformUtility.RectangleContainsScreenPoint(knife.GetComponent<RectTransform>(), position))
        {
            CutIngredient();
        }
    }

    void OpenRefrigerator()
    {
        isRefrigeratorOpen = true;
        // Logic to display ingredients
        Debug.Log("Refrigerator opened");
    }

    void CutIngredient()
    {
        // Logic to display chopped image
        choppedImage.gameObject.SetActive(true);
        Debug.Log("Ingredient cut");
    }
}
