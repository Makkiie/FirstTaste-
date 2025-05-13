using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public string itemID;
    public string itemType;
    public Image image;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas rootCanvas;

    private Vector3 originalScale;
    public Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        rootCanvas = GetComponentInParent<Canvas>();  // This finds the canvas automatically
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(rootCanvas.transform);  // Move to top-level canvas
        transform.SetAsLastSibling();               // Bring to front

        image.raycastTarget = false;                // Let us drop onto UI elements
        originalScale = transform.localScale;
        transform.localScale = originalScale * 1.1f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rootCanvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out localPoint))
        {
            rectTransform.localPosition = localPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(originalParent);
        transform.localPosition = Vector3.zero;

        image.raycastTarget = true;
        transform.localScale = originalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChoppingSessionData.itemID = itemID;
        ChoppingSessionData.itemType = itemType;
        ChoppingSessionData.originalSprite = image.sprite;

        SceneManager.LoadScene("ChoppingScene");
    }
}
