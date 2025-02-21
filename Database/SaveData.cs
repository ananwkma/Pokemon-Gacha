using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;

public class SaveData : MonoBehaviour
{
    private IDataService DataService = new JsonDataService();
    private bool EncryptionEnabled;

    public void ToggleEncryption(bool EncryptionEnabled) {
        this.EncryptionEnabled = EncryptionEnabled;
    }

    public void SaveToJson() {
        if (DataService.SaveData("/CharacterCollectionData.json", Player.cc, EncryptionEnabled)) {
            Debug.Log("Save success");
            try {
                Player.CharacterCollection data = DataService.LoadData<Player.CharacterCollection>("/CharacterCollectionData.json", EncryptionEnabled);
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
        Player.cc = DataService.LoadData<Player.CharacterCollection>("/CharacterCollectionData.json", EncryptionEnabled);
        // Debug.Log("Loaded:\r\n" + JsonConvert.SerializeObject(Player.cc, Formatting.Indented));
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
}
