using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using System.IO;

public class CharacterCollectionManager : MonoBehaviour
{
    [SerializeField] private CharacterIcon characterIconPrefab;
    public CharacterCollectionSlot[] teamBuilderSlots;
    public int currentTeamSize = 0;
    public CharacterCollectionSlot[] characterCollectionSlots;
    public CharacterIcon characterIconGoPrefab;
    
    public void SpawnNewCharacterIcon(CharacterIcon characterIcon, CharacterCollectionSlot slot) {
        CharacterIcon newCharacterIconGo = Instantiate(characterIconPrefab, slot.transform);
        CharacterIcon newCharacterIcon = newCharacterIconGo.GetComponent<CharacterIcon>(); 
        newCharacterIcon.InitializeCharacterIcon(characterIcon);
    }

    public void AddToTeamComp (CharacterIcon selectedCharacterIcon) {
        int teamSize = Player.PresetTeam.Count;
        SetCharacterIconPrefab(selectedCharacterIcon.Char, selectedCharacterIcon.Idx);
        SpawnNewCharacterIcon(characterIconPrefab, teamBuilderSlots[currentTeamSize]);
        currentTeamSize++;
    }

    // public void RemoveFromTeamComp (CharacterIcon selectedCharacterIcon) {
    //     characterCollectionSlots[]
    // }

    public void SetCharacterIconPrefab(Character character, int i) {
        characterIconPrefab.Title = character.Title;
        characterIconPrefab.CharacterName = character.Name;
        characterIconPrefab.Atk = character.Stats.Atk;
        characterIconPrefab.Def = character.Stats.Def;
        characterIconPrefab.Hp = character.Stats.Hp;
        characterIconPrefab.Mp = character.Stats.Mp;
        characterIconPrefab.Char = character;
        characterIconPrefab.Idx = i;
    }

    void LoadCharacters() {
        int i = 0;
        foreach (Character hero in Player.cc.characterCollection) {
            SetCharacterIconPrefab(hero, i);
            if (i < characterCollectionSlots.Length) SpawnNewCharacterIcon(characterIconPrefab, characterCollectionSlots[i]);
            i++;
        }
    }

    void ClearTeam() {
 
    }

    void Start()
    {
        LoadCharacters();
    }

    void Update() {
        // if (Player.PresetTeam.Count > currentTeamSize) {
            // AddToTeamComp(Player.PresetTeam[Player.PresetTeam.Count-1]);
            // Debug.Log("added: " + Player.PresetTeam[Player.PresetTeam.Count-1]);
        // }
    }
}
