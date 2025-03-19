using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Newtonsoft.Json;
using System;
using System.IO;

public class CharacterIcon : MonoBehaviour
{
    [Header("UI")]
    public Image image;
    public GameObject selectedButton;
    public int Idx;
    public Character Char;
    public CharacterCollectionManager ccm;
    public int id;

    void Start() {
        ccm = GameObject.FindWithTag("CCM").GetComponent<CharacterCollectionManager>();
    }

    public void InitializeCharacterIcon(Character newCharacter, int idx) {
        Idx = idx;
        Char = newCharacter;
        image.sprite = Resources.Load<Sprite>("Sprites/Icons/" + newCharacter.Title);
    }

    public void SetSelectedCharacter () {
        Player.selectedCharacter = Char;
    }

    public void ClearSelectedCharacter () {
        Player.selectedCharacter = null;
    }

    public void AddToTeamComp () {
        if (!Player.isMaxTeamSize()) {
            int idx = Player.cc.PresetTeam.Count;
            Player.cc.AddToTeam(Char);
            ccm.AddToTeamComp(Char);
            id = this.GetInstanceID();
            selectedButton.SetActive(true);
        } 
        ToggleInteractable();
    }

    public void ToggleInteractable() {
        Button button = GetComponent<Button>();
        if (button != null) {
            button.interactable = !button.interactable;
        } else {
            Debug.LogError("Button component not found on CharacterIcon.");
        }
    }

    public void RemoveFromTeamComp () {
        Player.cc.PresetTeam[Player.cc.PresetTeam.IndexOf(Char)] = null;
        
        ccm.RemoveFromTeamComp(Char);
        Destroy(this.gameObject);
        Destroy(this);
    }
    
}
