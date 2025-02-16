using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [Header("UI")]
    public Image image;

    [HideInInspector] public static Transform parentAfterDrag;
    [HideInInspector] public Item item;

    public void InitializeItem(Item newItem) {
        item = newItem;
        Debug.Log("name on init: " + item.CharacterName);
        image.sprite = Resources.Load<Sprite>("Sprites/Icons/" + newItem.Title);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

    public void SetSelectedCharacter () {
        Player.selectedCharacter = item;
        Debug.Log("item name" + item.CharacterName);
        Debug.Log("selected name" + Player.selectedCharacter.CharacterName);
    }

    public void ClearSelectedCharacter () {
        Player.selectedCharacter = null;
        Debug.Log("clear " + Player.selectedCharacter);
    }
}
