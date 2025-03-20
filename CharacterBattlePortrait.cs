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
    public Image selectedImage;
    public Image manaCrystal1;
    public Image manaCrystal2;
    public Image manaCrystal3;
    public Image manaCrystal4;
    public Image manaCrystal5;

    public TMP_Text nameText;
    public TMP_Text HPText;

    public Slider hpSlider;
    public Transform manaContainer;

    public Button characterButton;
    public Button enemySelection;
    public Button ultButton;

    public BattleSystem bs;    
    public CharacterBattleData charBDPrefab;
    public Character thisChar;    
    public CharacterBattleData thisCharBD;
    public bool isHero;
    public Image[] manaCrystalArray;

    void Awake() {
        Enable();
        bs = GameObject.FindWithTag("BS").GetComponent<BattleSystem>();
    }

    void Start() {
        if (isHero) {
            enemySelection.gameObject.SetActive(false);
            characterButton.interactable = true;
        }
        else {
            enemySelection.gameObject.SetActive(true);
            characterButton.interactable = false;
            enemySelection.onClick.AddListener(OnEnemyClick);
        }
        
        manaCrystalArray = new Image[] { manaCrystal1, manaCrystal2, manaCrystal3, manaCrystal4, manaCrystal5 };
    }

    public void Initialize(Character character)
    {
        thisChar = character;
        thisCharBD = Instantiate(charBDPrefab, transform);
        thisCharBD.SetCharBD(thisChar);

        SetHUD();
    }

    void OnEnemyClick() {
        BattleSystem.GetInstance().OnEnemySelected(this);
    }

    public void SetHUD() {
        nameText.text = thisChar.Name;
        HPText.text = thisCharBD.CurrentHP + " / " + thisCharBD.MaxHP;
        hpSlider.maxValue = thisCharBD.MaxHP;
        hpSlider.value = thisCharBD.CurrentHP;
        ultButton.gameObject.SetActive(false);
        Deselected();
    }

    public void SetHP(int dmg) {
        hpSlider.value -= dmg;
        if (thisCharBD.CurrentHP < 0) {
            HPText.text  = 0 + " / " + thisCharBD.MaxHP;
            if (isHero) {
                bs.numberOfHeroesAlive--;
            }
            else {
                bs.numberOfEnemiesAlive--;
            }
        }
        else {
            HPText.text = thisCharBD.CurrentHP + " / " + thisCharBD.MaxHP;
        }
    }

    public void AddMana(int currentMana) {
        for (int i = 0; i < currentMana; i++) {
            manaCrystalArray[i].color = Color.white;
        }
    }

    public void Attack() {
        bs.PlayerAttack(thisCharBD.GetAtk());
        thisCharBD.IncreaseMana();
        Disable();
    }

    public void ActivateAbility() {
        ultButton.gameObject.SetActive(true);
    }

    public void UseAbility() {
        for (int i = 0; i < thisCharBD.MaxMP; i++) {
            manaCrystalArray[i].color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }
        thisCharBD.UseAbility();
    }

    public void Selected() {
        if (!isHero) {
            selectedImage.gameObject.SetActive(true);
        }
    }

    public void Deselected() {
        selectedImage.gameObject.SetActive(false);
    }

    public void Dead() {
        Disable();
        Deselected();
        bs.DeselectAllEnemies();
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
