using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{    
    public Image image;
    public Color selectedColor, notSelectedColor;

    private void Awake() {
        Deselect();
    }

    public void Select() {
        image.color = selectedColor;
    }

    public void Deselect() {
        image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            // GameObject dropped = eventData.pointerDrag;
            InventoryItem characterIcon = eventData.pointerDrag.GetComponent<InventoryItem>();
            InventoryItem.parentAfterDrag = transform;
        }
    }
    
    public void OnClick(PointerEventData eventData) {
        Debug.Log(eventData.button);
        // ChangeSelectedSlot(number);
    }
}
