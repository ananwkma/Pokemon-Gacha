using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System;
using System.IO;

public class SelectedCharacterManager : MonoBehaviour
{
    [SerializeField] private Image CharacterRender;
    [SerializeField] private TMP_Text CharacterNameText;
    [SerializeField] private TMP_Text StatsText;

    void Start() {    
        Character myCharacter = Player.selectedCharacter;
        Debug.Log("myCharacter: " + JsonConvert.SerializeObject(myCharacter, Formatting.Indented));
        CharacterNameText.text = myCharacter.Name;
        CharacterRender.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + myCharacter.Title);
        StatsText.text = "HP: " + myCharacter.Stats.Hp + "\n" + 
                "MP: " + myCharacter.Stats.Mp + "\n" + 
                "ATK: " + myCharacter.Stats.Atk + "\n" + 
                "DEF: " + myCharacter.Stats.Def;
    }
}
