using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterCollectionSlot : MonoBehaviour, IDropHandler
{    
    public Image image;
    public Color selectedColor, notSelectedColor;
    public bool selected;

    private void Awake() {
        selected = false;
    }

    public void Select() {
        selected = !selected;
        image.color = (selected ? selectedColor : notSelectedColor);
    }

    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            // GameObject dropped = eventData.pointerDrag;
            CharacterIcon characterIcon = eventData.pointerDrag.GetComponent<CharacterIcon>();
            CharacterIcon.parentAfterDrag = transform;
        }
    }
    
    public void OnClick(PointerEventData eventData) {
        Debug.Log("CCS CLICKED");
        // ChangeSelectedSlot(number);
    }
}
