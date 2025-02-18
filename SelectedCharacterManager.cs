using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SelectedCharacterManager : MonoBehaviour
{
    [SerializeField] private Image CharacterRender;
    [SerializeField] private TMP_Text CharacterNameText;
    [SerializeField] private TMP_Text StatsText;

    void Start() {    
        Item myCharacter = Player.selectedCharacter;
        CharacterNameText.text = myCharacter.CharacterName;
        CharacterRender.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + myCharacter.Title);
        StatsText.text = "HP: " + myCharacter.Hp + "\n" + 
                "MP: " + myCharacter.Mp + "\n" + 
                "ATK: " + myCharacter.Atk + "\n" + 
                "DEF: " + myCharacter.Def;
    }
}
