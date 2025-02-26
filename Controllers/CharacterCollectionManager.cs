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

    private static CharacterCollectionManager instance;

    public static CharacterCollectionManager GetInstance() {
        return instance;
    }

    public void SpawnNewCharacterIcon(Character character, int idx, CharacterCollectionSlot[] array) {
        CharacterIcon newCharacterIconGo = Instantiate(characterIconPrefab, array[idx].transform);
        newCharacterIconGo.InitializeCharacterIcon(character, idx);
    }

    public void AddToTeamComp (Character selectedCharacter) {
        int teamSize = Player.cc.PresetTeam.Count;
        SpawnNewCharacterIcon(selectedCharacter, currentTeamSize, teamBuilderSlots);
        currentTeamSize++;
    }

    // public void RemoveFromTeamComp (CharacterIcon selectedCharacterIcon) {
    //     characterCollectionSlots[]
    // }

    public void SetCharacterIconPrefab(Character character, int i) {
        characterIconPrefab.Char = character;
        characterIconPrefab.Idx = i;
    }

    void LoadCharacters() {
        int i = 0;
        foreach (Character hero in Player.cc.characterCollection) {
            SetCharacterIconPrefab(hero, i);
            if (i < characterCollectionSlots.Length) SpawnNewCharacterIcon(hero, i, characterCollectionSlots);
            i++;
        }
    }

    void Start()
    {
        LoadCharacters();
    }

    void Update() {
        // if (Player.cc.PresetTeam.Count > currentTeamSize) {
        //     AddToTeamComp(Player.cc.PresetTeam[Player.cc.PresetTeam.Count-1]);
        //     Debug.Log("added: " + Player.cc.PresetTeam[Player.cc.PresetTeam.Count-1]);
        // }
    }
}
