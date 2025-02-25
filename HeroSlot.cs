using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroSlot : MonoBehaviour
{
    public Image heroImage;
    public TMP_Text nameText;
    public TMP_Text HPText;
    public Slider hpSlider;

    public void SetHUD(Unit unit) {
        nameText.text = unit.unitName;
        HPText.text = unit.currentHP + "/" + unit.maxHP;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP(int hp) {
        hpSlider.value = hp;
    }
}
