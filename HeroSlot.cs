using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

public class HeroSlot : MonoBehaviour
{
    public Image heroImage;
    public TMP_Text nameText;
    public TMP_Text HPText;
    public Slider hpSlider;
    public BattleSystem bs;
    public Character thisChar;
    public Button heroSlotButton;

    void Start() {
        bs = GameObject.FindWithTag("BS").GetComponent<BattleSystem>();
        Enable();
    }

    public void SetHUD() {
        // Debug.Log("thisChar " + JsonConvert.SerializeObject(thisChar, Formatting.Indented));
        thisChar.CurrentHP = thisChar.Stats.Hp;
        thisChar.MaxHP = thisChar.Stats.Hp;
        nameText.text = thisChar.Name;
        HPText.text = thisChar.CurrentHP + "/" + thisChar.MaxHP;
        hpSlider.maxValue = thisChar.MaxHP;
        hpSlider.value = thisChar.CurrentHP;
    }

    public void SetHP(int hp) {
        hpSlider.value = hp;
    }

    public void Attack() {
        bs.StartCoroutine(bs.PlayerAttack());
        Disable();
    }

    public void Disable() {
        heroSlotButton.interactable = false;
        Color diabledColor = heroImage.color;
        diabledColor.a = 0.3f; 
        heroImage.color = diabledColor;
    }
    
    public void Enable() {
        heroSlotButton.interactable = true;
        Color enabledColor = heroImage.color;
        enabledColor.a = 1.0f; 
        heroImage.color = enabledColor;
    }
}
