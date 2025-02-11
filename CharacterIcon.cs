using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Character character;

    [Header("UI")]
    public Image image;

    [HideInInspector] public Transform parentAfterDrag;

    private void Start() {
        InitializeCharacterIcon(character);
    }

    public void InitializeCharacterIcon(Character newCharacter) {
        // image.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + newCharacter.Title);
    }

    public void OnBeginDrag(PointerEventData eventData) {
        Debug.Log("Begin drag");
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData) {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End drag");
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }


    // private Character myCharacter;
    // private Image icon;
    
    // public Character MyCharacter { get; set; }
    // public Image Icon { get; set; }

    // public CharacterIcon() { }

    // public CharacterIcon(Character myCharacter, Image icon)
    // {
    //     MyCharacter = myCharacter;
    //     Icon = icon;
    // }
    
    // public void AddThisToTeamComp() {
    //     TeamBuilderController.AddToTeamComp(MyCharacter);
    // }
}
