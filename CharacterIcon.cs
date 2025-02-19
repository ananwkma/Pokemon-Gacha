using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Newtonsoft.Json;
using System;
using System.IO;

public class CharacterIcon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public GameObject selectedButton;

    public string CharacterName;
    public string Title;
    public int Atk;
    public int Def;
    public int Hp;
    public int Mp;
    public int Idx;

    public Character Char;

    [HideInInspector] public static Transform parentAfterDrag;
    [HideInInspector] public CharacterIcon characterIcon;
    public static List<Character> teamComp;

    public void InitializeCharacterIcon(CharacterIcon newCharacterIcon) {
        characterIcon = newCharacterIcon;
        CharacterName = newCharacterIcon.CharacterName;
        Title = newCharacterIcon.Title;
        Atk = newCharacterIcon.Atk;
        Def = newCharacterIcon.Def;
        Hp = newCharacterIcon.Hp;
        Mp = newCharacterIcon.Mp;
        Char = newCharacterIcon.Char;
        Idx = newCharacterIcon.Idx;
        image.sprite = Resources.Load<Sprite>("Sprites/Icons/" + newCharacterIcon.Title);
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
        Player.selectedCharacter = characterIcon;
        Player.selectedCharacter.Char = Char;
        Player.selectedCharacter.CharacterName = CharacterName;
        Player.selectedCharacter.Title = Title;
        Player.selectedCharacter.Atk = Atk;
        Player.selectedCharacter.Def = Def;
        Player.selectedCharacter.Hp = Hp;
        Player.selectedCharacter.Mp = Mp;
        Player.selectedCharacter.Idx = Idx;
    }

    public void ClearSelectedCharacter () {
        Player.selectedCharacter = null;
        Debug.Log("clear " + Player.selectedCharacter);
    }

    public void AddToTeamComp () {
        if (!Player.isMaxTeamSize()) {
            Player.PresetTeam.Add(Char);
            selectedButton.SetActive(true);
            Debug.Log("Player.PresetTeam: " + JsonConvert.SerializeObject(Player.PresetTeam, Formatting.Indented));
        } 
    }

    public void RemoveFromTeamComp () {
        // Player.PresetTeam.Add(Char);
        selectedButton.SetActive(false);
        // Debug.Log("Player.PresetTeam: " + JsonConvert.SerializeObject(Player.PresetTeam, Formatting.Indented));
    }
}