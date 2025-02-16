using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SelectedCharacterManager : MonoBehaviour
{
    [SerializeField] private Image characterRender;
    [SerializeField] private TMP_Text name;
    [SerializeField] private TMP_Text stats;

    void Start() {    
        Item myCharacter = Player.selectedCharacter;
        name.text = myCharacter.CharacterName;
        Debug.Log("TEST: " + Player.selectedCharacter);
        characterRender.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + myCharacter.Title);
        stats.text = "HP: " + myCharacter.Hp + "\n" + 
                "MP: " + myCharacter.Mp + "\n" + 
                "ATK: " + myCharacter.Atk + "\n" + 
                "DEF: " + myCharacter.Def;
    }
}
