using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;

public class SaveData : MonoBehaviour
{
    public static CharacterCollection cc = new CharacterCollection();
    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;

    public void ToggleEncryption(bool EncryptionEnabled) {
        this.EncryptionEnabled = EncryptionEnabled;
    }

    public void SaveToJson() {
        if (DataService.SaveData("/CharacterCollectionData.json", cc, EncryptionEnabled)) {
            Debug.Log("Save success");
            try {
                CharacterCollection data = DataService.LoadData<CharacterCollection>("/CharacterCollectionData.json", EncryptionEnabled);
                Debug.Log("Loaded:\r\n" + JsonConvert.SerializeObject(data, Formatting.Indented));
            }
            catch (Exception e) {
                Debug.LogError($"Failed to load data due to: {e.Message} {e.StackTrace}");
                throw e;
            }
        }
        else {
            Debug.LogError("Could not save file! Show something on the UI about it!");
        }
    }

    public void LoadFromJson() {
        cc = DataService.LoadData<CharacterCollection>("/CharacterCollectionData.json", EncryptionEnabled);
        // Debug.Log("Loaded:\r\n" + JsonConvert.SerializeObject(cc, Formatting.Indented));
    }
    
    void Awake()
    {
        LoadFromJson();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)) {
            SaveToJson();
        }
        if(Input.GetKeyDown(KeyCode.L)) {
            LoadFromJson();
        }
    }
    
    [System.Serializable]
    public class CharacterCollection {
        public List<Character> characterCollection = new List<Character>();
        public void Add(Character character) {
            characterCollection.Add(character);
        }
    }
}
