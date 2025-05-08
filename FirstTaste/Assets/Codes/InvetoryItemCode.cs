using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.Android.Gradle.Manifest;

public class InvetoryItemCode : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    [HideInInspector] public Transform parentsAfterDrag;
  
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        image.raycastTarget =false;
        parentsAfterDrag = transform.parent;
        transform.SetParent(transform.root);

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Ondrag");
       transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        image.raycastTarget=true;
        transform.SetParent(parentsAfterDrag);
    }
}
