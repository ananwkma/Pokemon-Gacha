using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterCollectionManager : MonoBehaviour
{
    // public static List<Character> teamComp;
    // private static int TEAMSIZEMAX = 4;

    public CharacterCollectionSlot[] characterCollectionSlots;
    public GameObject characterIconPrefab;
    // int selectedSlot = -1;

    // public bool AddCharacterIcon(CharacterIcon characterIcon) {
    //     for (int i = 0; i < characterCollectionSlots.Length; i++) {
    //         CharacterCollectionSlot slot = characterCollectionSlots[i];
    //         CharacterIcon characterIconInSlot = slot.GetComponentInChildren<CharacterIcon>();
    //         if (characterIconInSlot == null) {
    //             SpawnNewCharacterIcon(characterIcon, slot);
    //             return true;
    //         }
    //     }
    //     return false;
    // }

    public void SpawnNewCharacterIcon(CharacterIcon characterIcon, CharacterCollectionSlot slot) {
        GameObject newCharacterIconGo = Instantiate(characterIconPrefab, slot.transform);
        CharacterIcon newCharacterIcon = newCharacterIconGo.GetComponent<CharacterIcon>(); 
        newCharacterIcon.InitializeCharacterIcon(characterIcon);
    }

    // void ChangeSelectedSlot(int newValue) {
    //     if (selectedSlot >= 0) {
    //         Character characterInSlot = characterCollectionSlots[selectedSlot].GetComponentInChildren<Character>();
    //         CharacterIcon characterIconInSlot = characterCollectionSlots[selectedSlot].GetComponentInChildren<CharacterIcon>();
    //         characterIconInSlot.SetSelectedCharacter();
    //         Player.PresetTeam.Add(characterInSlot);
    //         characterCollectionSlots[selectedSlot].Select();
    //     }
    // }

    // public CharacterIcon GetSelectedCharacterIcon(bool use) {
    //     CharacterCollectionSlot slot = characterCollectionSlots[selectedSlot];
    //     CharacterIcon characterIconInSlot = slot.GetComponentInChildren<CharacterIcon>();
    //     if (characterIconInSlot != null) {
    //         CharacterIcon characterIcon = characterIconInSlot;
    //         Debug.Log(characterIcon);
    //         return characterIcon;
    //     }

    //     return null;
    // }

    // public static void AddToTeamComp(Character character) {
    //     if (teamComp.Count < TEAMSIZEMAX) {
    //         teamComp.Add(character);
    //     }
    // }

    // public void RemoveFromTeamComp(Character character) {
    //     if (teamComp.Count > 0) {
    //         teamComp.Remove(character);
    //     }
    // }

    // private void Update() {
    //     if (Input.inputString != null) {
    //         bool isNumber = int.TryParse(Input.inputString, out int number);
    //         if (isNumber && number > 0 && number < 8) {
    //             ChangeSelectedSlot(number - 1);
    //         }
    //     }
    // }
}
