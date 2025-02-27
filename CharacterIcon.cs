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
    public CharacterCollectionManager ccm;
    public int id;

    void Start() {
        ccm = GameObject.FindWithTag("CCM").GetComponent<CharacterCollectionManager>();
        Debug.Log("Get CCM " + GameObject.FindWithTag("CCM"));
    }

    public void InitializeCharacterIcon(Character newCharacter, int idx) {
        Idx = idx;
        Char = newCharacter;
        Debug.Log("id at instantiate: " + id);
        image.sprite = Resources.Load<Sprite>("Sprites/Icons/" + newCharacter.Title);
    }

    public void SetSelectedCharacter () {
        Player.selectedCharacter = Char;
    }

    public void ClearSelectedCharacter () {
        Player.selectedCharacter = null;
    }

    public void AddToTeamComp () {
        if (!Player.isMaxTeamSize()) {
            int idx = Player.cc.PresetTeam.Count;
            Player.cc.PresetTeam.Add(Char);
            ccm.AddToTeamComp(Char);
            id = this.GetInstanceID();
            Debug.Log("id: " + id);
            selectedButton.SetActive(true);
        } 
    }

    public void RemoveFromTeamComp () {
        Player.cc.PresetTeam.Remove(Char);
        ccm.RemoveFromTeamComp(this);
        Destroy(this.gameObject);
        Destroy(this);
    }
    
}
