using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Image blankImage;

    public void OnDrop(PointerEventData eventData)
    {
        Draggable item = eventData.pointerDrag.GetComponent<Draggable>();
        if (item != null)
        {
            blankImage.sprite = item.GetComponent<Image>().sprite;

            GameManager.Instance.StartChopping(item.gameObject.name, blankImage.sprite);
        }
    }
}
