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
    [SerializeField] private Image rarityStar;
    [SerializeField] private Image rarityStar2;
    [SerializeField] private Image rarityStar3;
    [SerializeField] private Image rarityStar4;
    [SerializeField] private Image rarityStar5;
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

    public void populateDescriptionText(Character roll) {
        descriptionText.text = "HP " + roll.Stats.Hp + "\nMP " + roll.Stats.Mp + "\nATK " + roll.Stats.Atk + "\nDEF " + roll.Stats.Def;
        descriptionText.enabled = true;
    }

    public void disableStars() {
        rarityStar.enabled = false;
        rarityStar2.enabled = false;
        rarityStar3.enabled = false;
        rarityStar4.enabled = false;
        rarityStar5.enabled = false;
    }

    public void updateCharacterObject(Character roll) {
        characterImage.color = new Color32(255,255,255,255);
        characterImage.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + roll.Title);
        characterNameText.text = roll.Name;
    }

    public void populateStars(Character roll) {
        switch (roll.Stats.Rarity) {
            case 1:
                rarityStar.enabled = true;
                break;
            case 2:
                rarityStar.enabled = true;
                rarityStar2.enabled = true;
                break;
            case 3:
                rarityStar.enabled = true;
                rarityStar2.enabled = true;
                rarityStar3.enabled = true;
                break;
            case 4:
                rarityStar.enabled = true;
                rarityStar2.enabled = true;
                rarityStar3.enabled = true;
                rarityStar4.enabled = true;
                break;
            case 5:
                rarityStar.enabled = true;
                rarityStar2.enabled = true;
                rarityStar3.enabled = true;
                rarityStar4.enabled = true;
                rarityStar5.enabled = true;
                break;
        }
    }

    public void GachaButtonPress() {
        if (Player.gems >= 100) {
            Character roll = GetRoll(GetRNG()).Clone();
            roll.Id = System.Guid.NewGuid().ToString();

            disableStars();
            updateCharacterObject(roll);
            populateDescriptionText(roll);
            populateStars(roll);

            Player.cc.Add(roll);

            Player.gems -= 100;
            InfoBarController.Instance.UpdateGems();
        }
    }

    void Start () {
        if (descriptionText) descriptionText.enabled = false;
        if (rarityStar) disableStars();
        if (characterImage) characterImage.color = new Color32(255,255,255,0);
    }
}
