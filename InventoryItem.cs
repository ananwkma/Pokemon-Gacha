using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;

    public string CharacterName;
    public string Title;
    public int Atk;
    public int Def;
    public int Hp;
    public int Mp;

    [HideInInspector] public static Transform parentAfterDrag;
    [HideInInspector] public InventoryItem item;

    public void InitializeItem(InventoryItem newItem) {
        item = newItem;
        CharacterName = newItem.CharacterName;
        Title = newItem.Title;
        Atk = newItem.Atk;
        Def = newItem.Def;
        Hp = newItem.Hp;
        Mp = newItem.Mp;
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
        Player.selectedCharacter.CharacterName = CharacterName;
        Player.selectedCharacter.Title = Title;
        Player.selectedCharacter.Atk = Atk;
        Player.selectedCharacter.Def = Def;
        Player.selectedCharacter.Hp = Hp;
        Player.selectedCharacter.Mp = Mp;
        Debug.Log("Player.selectedCharacter: " + Player.selectedCharacter.CharacterName);
    }

    public void ClearSelectedCharacter () {
        Player.selectedCharacter = null;
        Debug.Log("clear " + Player.selectedCharacter);
    }
}