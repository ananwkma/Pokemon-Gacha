using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterCollectionSlot : MonoBehaviour
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
    
    public void OnClick(PointerEventData eventData) {
        Debug.Log("CCS CLICKED");
        // ChangeSelectedSlot(number);
    }
}
