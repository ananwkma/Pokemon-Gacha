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

    public void InitializeCharacterIcon(Character newCharacter, int idx) {
        Idx = idx;
        Char = newCharacter;
        image.sprite = Resources.Load<Sprite>("Sprites/Icons/" + newCharacter.Title);
    }

    public void SetSelectedCharacter () {
        Player.selectedCharacter = Char;
        Debug.Log("Player.selectedCharacter " + JsonConvert.SerializeObject(Player.selectedCharacter, Formatting.Indented));
        Debug.Log("Char " + JsonConvert.SerializeObject(Char, Formatting.Indented));
    }

    public void ClearSelectedCharacter () {
        Player.selectedCharacter = null;
    }

    public void AddToTeamComp () {
        if (!Player.isMaxTeamSize()) {
            int idx = Player.PresetTeam.Count;
            Player.PresetTeam.Add(this);
            selectedButton.SetActive(true);
        } 
    }

    public void RemoveFromTeamComp () {
        // Player.PresetTeam.Remove(new KeyValuePair<int, Character>(Idx, Char);
        // Player.PresetTeam.Add(Char);
        selectedButton.SetActive(false);
        // Debug.Log("Player.PresetTeam: " + JsonConvert.SerializeObject(Player.PresetTeam, Formatting.Indented));
    }
    
}
