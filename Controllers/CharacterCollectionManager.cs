using System.Collections.Generic;
using UnityEngine;

public class CharacterCollectionManager : MonoBehaviour
{
    [SerializeField] private CharacterIcon characterIconPrefab;
    [SerializeField] private CharacterIcon teamIconPrefab;
    public CharacterCollectionSlot[] teamBuilderSlots;
    public CharacterCollectionSlot[] characterCollectionSlots;

    public int currentTeamSize = 0;
    private static CharacterCollectionManager instance;

    public static CharacterCollectionManager Instance => instance;

    void Awake() {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        LoadCharacters();
    }

    public void SpawnNewCharacterIcon(Character character, int idx, CharacterCollectionSlot[] array) {
        if (array == null || idx < 0 || idx >= array.Length || character == null) {
            Debug.LogError("Invalid parameters for SpawnNewCharacterIcon");
            return;
        }
        
        CharacterIcon prefabToUse = array == teamBuilderSlots ? teamIconPrefab : characterIconPrefab;
        CharacterIcon newCharacterIcon = Instantiate(prefabToUse, array[idx].transform);
        newCharacterIcon.InitializeCharacterIcon(character, idx);

        // if (array == teamBuilderSlots) {
        //     idx = FindNextAvailableSlot();
        //     CharacterIcon newCharacterIconGo = Instantiate(teamIconGoPrefab, array[idx].transform);
        //     newCharacterIconGo.InitializeCharacterIcon(character, idx);
        // }
        // else if (array == characterCollectionSlots) {
        //     CharacterIcon newCharacterIconGo = Instantiate(characterIconPrefab, array[idx].transform);
        //     newCharacterIconGo.InitializeCharacterIcon(character, idx);
        // }
    }

    public void AddToTeamComp (Character selectedCharacter) {
        if (selectedCharacter == null || currentTeamSize >= teamBuilderSlots.Length) return;

        int slotIndex = FindNextAvailableSlot();
        if (slotIndex == -1) return;

        SpawnNewCharacterIcon(selectedCharacter, slotIndex, teamBuilderSlots);
        currentTeamSize++;
    }

    public void RemoveFromTeamComp (Character selectedCharacter) {
        if (selectedCharacter == null) return;
        
        foreach (var slot in characterCollectionSlots) {
            if (slot.transform.childCount > 0) {
                CharacterIcon characterIcon = slot.transform.GetChild(0).GetComponent<CharacterIcon>();
                if (characterIcon != null && characterIcon.Char.Id == selectedCharacter.Id) {
                    characterIcon.selectedButton.SetActive(false);
                    break;
                }
            }
        }
        currentTeamSize = Mathf.Max(0, currentTeamSize - 1);
    }

    public int FindNextAvailableSlot () {
        for (int i = 0; i < teamBuilderSlots.Length; i++) {
            if (teamBuilderSlots[i].transform.childCount == 0) {
                return i;
            }
        }
        return -1;
    }

    // public void SetCharacterIconPrefab(Character character, int i) {
    //     characterIconPrefab.Char = character;
    //     characterIconPrefab.Idx = i;
    // }

    void LoadCharacters() {
        if (Player.cc?.characterCollection == null) return;

        int i = 0;
        foreach (Character hero in Player.cc.characterCollection) {
            if (i >= characterCollectionSlots.Length) break;
            SpawnNewCharacterIcon(hero, i, characterCollectionSlots);
            i++;
        }
    }
}
