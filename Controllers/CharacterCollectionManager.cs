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
    public CharacterCollectionSlot[] characterCollectionSlots;
    public int currentTeamSize = 0;
    public CharacterIcon characterIconGoPrefab;
    public CharacterIcon teamIconGoPrefab;

    private static CharacterCollectionManager instance;

    public static CharacterCollectionManager GetInstance() {
        return instance;
    }

    public void SpawnNewCharacterIcon(Character character, int idx, CharacterCollectionSlot[] array) {
        if (array == teamBuilderSlots) {
            idx = FindNextAvailableSlot();
            CharacterIcon newCharacterIconGo = Instantiate(teamIconGoPrefab, array[idx].transform);
            newCharacterIconGo.InitializeCharacterIcon(character, idx);
        }
        else if (array == characterCollectionSlots) {
            CharacterIcon newCharacterIconGo = Instantiate(characterIconPrefab, array[idx].transform);
            newCharacterIconGo.InitializeCharacterIcon(character, idx);
        }
    }

    public void AddToTeamComp (Character selectedCharacter) {
        int teamSize = Player.cc.PresetTeam.Count;
        SpawnNewCharacterIcon(selectedCharacter, currentTeamSize, teamBuilderSlots);
        currentTeamSize++;
    }

    public void RemoveFromTeamComp (Character selectedCharacter) {
        for (int i = 0; i < Player.cc.characterCollection.Count; i++) {
            if (characterCollectionSlots[i].transform.GetChild(0).GetComponent<CharacterIcon>().Char.Id == selectedCharacter.Id) {
                characterCollectionSlots[i].transform.GetChild(0).GetComponent<CharacterIcon>().selectedButton.SetActive(false);
            }
        }        
        currentTeamSize--;
    }

    public int FindNextAvailableSlot () {
        for (int i = 0; i < teamBuilderSlots.Length; i++) {
            if (teamBuilderSlots[i].transform.childCount == 0) {
                return i;
            }
        }
        return -1;
    }

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
}
