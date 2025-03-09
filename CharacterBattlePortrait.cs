using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

public class CharacterBattlePortrait : MonoBehaviour
{
    public Image heroImage;
    public Image DeadImage;
    public TMP_Text nameText;
    public TMP_Text HPText;
    public Slider hpSlider;
    public Button characterButton;
    public BattleSystem bs;    
    public CharacterBattleData charBDPrefab;
    public Character thisChar;    
    public CharacterBattleData thisCharBD;


    void Awake() {
        Enable();
        bs = GameObject.FindWithTag("BS").GetComponent<BattleSystem>();
    }

    public void Initialize(Character character)
    {
        thisChar = character;
        thisCharBD = Instantiate(charBDPrefab, transform);
        thisCharBD.SetCharBD(thisChar);

        SetHUD();
    }

    public void SetHUD() {
        // Debug.Log("thisChar " + JsonConvert.SerializeObject(thisChar, Formatting.Indented));
        nameText.text = thisChar.Name;
        HPText.text = thisCharBD.CurrentHP + " / " + thisCharBD.MaxHP;
        hpSlider.maxValue = thisCharBD.MaxHP;
        hpSlider.value = thisCharBD.CurrentHP;
    }

    public void SetHP(int dmg) {
        hpSlider.value -= dmg;
        if (thisCharBD.CurrentHP < 0) {
            HPText.text  = 0 + " / " + thisCharBD.MaxHP;
        }
        else {
            HPText.text = thisCharBD.CurrentHP + " / " + thisCharBD.MaxHP;
        }
    }

    public void Attack() {
        bs.PlayerAttack(thisCharBD.GetAtk());
        Disable();
    }

    public void Dead() {
        Disable();
        DeadImage.gameObject.SetActive(true);
    }

    public void Disable() {
        characterButton.interactable = false;
        Color diabledColor = heroImage.color;
        diabledColor.a = 0.3f; 
        heroImage.color = diabledColor;
    }
    
    public void Enable() {
        characterButton.interactable = true;
        Color enabledColor = heroImage.color;
        enabledColor.a = 1.0f; 
        heroImage.color = enabledColor;
    }
}
