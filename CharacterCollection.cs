using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCollection : MonoBehaviour
{
    [SerializeField] private Item itemPrefab;
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;

    string GetContainerTag(int sceneIndex) {
        switch (sceneIndex) {
            case 2:
                return "CharacterCollection";
            case 6: 
                return "CharacterSelection";
            default:
                return "";
        }
    } 

    void LoadCharacters() {
        int i = 0;
        string containerTag = GetContainerTag(SceneNavManager.GetActiveScene());
        if (containerTag == "CharacterSelection") i = 4;

        foreach (Character hero in SaveData.cc.characterCollection) {
            itemPrefab.Title = hero.Title;
            itemPrefab.CharacterName = hero.Name;
            itemPrefab.Atk = hero.Stats.Atk;
            itemPrefab.Def = hero.Stats.Def;
            itemPrefab.Hp = hero.Stats.Hp;
            itemPrefab.Mp = hero.Stats.Mp;
            itemPrefab.Description = "testzzzz";
            Debug.Log("loadchars " + itemPrefab.CharacterName);
            Debug.Log("name json " + hero.Name);
            Debug.Log("name prespawn " + itemPrefab.CharacterName);
            inventoryManager.SpawnNewItem(itemPrefab, inventoryManager.inventorySlots[i]);
            i++;
        }
    }

    void Start()
    {
        LoadCharacters();
    }
}
