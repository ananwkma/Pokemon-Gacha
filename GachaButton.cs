using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GachaButton : MonoBehaviour
{
    [SerializeField] private TMP_Text characterNameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image characterImage;    
    [SerializeField] private Image[] rarityStars;

    float rng;

    private int GetRNG() {
        return Random.Range(0, 100);
    }

    private Character GetRoll(int rng) {
        if (rng >= 90) {
            return CharacterDatabase.rollTableSuper[Random.Range(0, CharacterDatabase.rollTableSuper.Length)];
        }
        else if (rng >= 70) {
            return CharacterDatabase.rollTableRare[Random.Range(0, CharacterDatabase.rollTableRare.Length)];
        }
        else {
            return CharacterDatabase.rollTableCommon[Random.Range(0, CharacterDatabase.rollTableCommon.Length)];
        }
    }

    public void PopulateDescriptionText(Character roll) {
        descriptionText.text = "HP " + roll.Stats.Hp + "\nMP " + roll.Stats.Mp + "\nATK " + roll.Stats.Atk + "\nDEF " + roll.Stats.Def;
        descriptionText.enabled = true;
    }

    public void DisableStars() {
        foreach (var star in rarityStars)
        {
            if (star) star.enabled = false;
        }

    }

    public void UpdateCharacterObject(Character roll) {
        if (characterImage)
        {
            characterImage.color = Color.white;
            characterImage.sprite = Resources.Load<Sprite>($"Sprites/FullRender/{roll.Title}");
        }

        if (characterNameText) characterNameText.text = roll.Name;
    }

    public void PopulateStars(Character roll) {
        int rarity = roll.Stats.Rarity;
        for (int i = 0; i < rarity; i++)
        {
            if (i < rarityStars.Length) rarityStars[i].enabled = true;
        }
    }

    public void GachaButtonPress() {
        if (Player.gems < 100) return;

        int rng = GetRNG();
        Character roll = GetRoll(rng).Clone();
        roll.Id = System.Guid.NewGuid().ToString();

        DisableStars();
        UpdateCharacterObject(roll);
        PopulateDescriptionText(roll);
        PopulateStars(roll);

        Player.cc.Add(roll);
        Player.gems -= 100;
        InfoBarController.Instance.UpdateGems();
    }

    void Start () {
        if (descriptionText) descriptionText.enabled = false;
        if (characterImage) characterImage.color = new Color32(255,255,255,0);
        DisableStars();
    }
}
