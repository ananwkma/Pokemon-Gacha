using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedCharacterManager : MonoBehaviour
{
    [SerializeField] private Image characterRender;
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text statsText;

    private void Start() {   
        if (Player.selectedCharacter == null) {
            Debug.LogWarning("No character selected");
            return;
        } 
        
        Character myCharacter = Player.selectedCharacter;
        
        if (characterNameText) {
            characterNameText.text = myCharacter.Name;
        }

        if (characterRender) {
            characterRender.sprite = Resources.Load<Sprite>($"Sprites/FullRender/{myCharacter.Title}");
        }

        if (statsText) {
            statsText.text = $"HP: {myCharacter.Stats.Hp}\n" + 
                             $"MP: {myCharacter.Stats.Mp}\n" +
                             $"ATK: {myCharacter.Stats.Atk}\n" +
                             $"DEF: {myCharacter.Stats.Def}\n";
        }
    }
}
