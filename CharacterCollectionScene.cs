using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System;
using System.IO;

public class CharacterCollectionScene : MonoBehaviour
{
    [SerializeField] private CharacterIcon characterIconPrefab;
    public CharacterCollectionManager characterCollectionManager;

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

        foreach (Character hero in Player.cc.characterCollection) {
            characterIconPrefab.Title = hero.Title;
            characterIconPrefab.CharacterName = hero.Name;
            characterIconPrefab.Atk = hero.Stats.Atk;
            characterIconPrefab.Def = hero.Stats.Def;
            characterIconPrefab.Hp = hero.Stats.Hp;
            characterIconPrefab.Mp = hero.Stats.Mp;
            characterIconPrefab.Char = hero;
            characterIconPrefab.Idx = i;
            
            characterCollectionManager.SpawnNewCharacterIcon(characterIconPrefab, characterCollectionManager.characterCollectionSlots[i]);
            i++;
        }
    }

    void Start()
    {
        LoadCharacters();
    }
}
