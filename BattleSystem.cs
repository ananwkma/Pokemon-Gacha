using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private static BattleSystem instance;
    public static BattleSystem GetInstance() => instance;

    public CharacterBattlePortrait charBPPrefab;
    public Transform playerBattleStation, enemyBattleStation;
    public TMP_Text dialogueText;
    public Image EndScreen;
    public BattleState state;

    private int numberOfHeroesAlive, numberOfEnemiesAlive, movesRemaining;
    public static List<CharacterBattlePortrait> heroList = new List<CharacterBattlePortrait>();
    public static List<CharacterBattlePortrait> enemiesList = new List<CharacterBattlePortrait>();

    void Start()
    {
        instance = this;
        state = BattleState.START;
        EndScreen.gameObject.SetActive(false);
        heroList.Clear();
        enemiesList.Clear();
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() {
        PopulateCharacters(Player.cc.PresetTeam, playerBattleStation, heroList);
        PopulateCharacters(Player.GetCurrentCheckpoint().Enemies, enemyBattleStation, enemiesList);

        numberOfHeroesAlive = Player.cc.PresetTeam.Count;
        numberOfEnemiesAlive = enemiesList.Count;
        movesRemaining = Player.cc.PresetTeam.Count;

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PopulateCharacters(List<Character> charList, Transform battleStation, List<CharacterBattlePortrait> charBPList) {
        foreach (Character thisChar in charList) {
            CharacterBattlePortrait charBP = Instantiate(charBPPrefab, battleStation);
            charBP.Initialize(thisChar);

            charBP.SetHUD();
            charBP.heroImage.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + thisChar.Title);
            charBPList.Add(charBP);
        }
    }
    
    public void PlayerAttack(int atk) {

        CharacterBattlePortrait selectedEnemyBP = enemiesList[0];
        CharacterBattleData selectedEnemyBD = enemiesList[0].thisCharBD;
        int damage = CalculateDamage(atk, selectedEnemyBD.GetDef());
        selectedEnemyBD.TakeDamage(damage);
        selectedEnemyBP.SetHP(damage);

        dialogueText.text = "The attack is successful";

        movesRemaining--;

        updateAliveEnemies();

        if (movesRemaining == 0 && numberOfEnemiesAlive > 0) {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    
    IEnumerator EnemyTurn() {
        if (state == BattleState.ENEMYTURN) {
            CharacterBattlePortrait selectedEnemyBP = enemiesList[0];
            CharacterBattleData selectedEnemyBD = enemiesList[0].thisCharBD;

            CharacterBattlePortrait selectedHeroBP = getNextAliveHero();
            CharacterBattleData selectedHeroBD = getNextAliveHero().thisCharBD;

            int damage = CalculateDamage(selectedEnemyBD.GetAtk(), selectedHeroBD.GetDef());

            dialogueText.text = selectedEnemyBD.thisChar.Name + " attacks!";

            yield return new WaitForSeconds(1f);

            selectedHeroBD.TakeDamage(damage);
            selectedHeroBP.SetHP(damage);

            updateAliveHeroes();
            movesRemaining = numberOfHeroesAlive;
        }
    }

    void EndBattle() {
        EndScreen.gameObject.SetActive(true);
        if (state == BattleState.WON) {
            dialogueText.text = "You won the battle!";
            Player.IncrementCheckpoint();
        }
        else if (state == BattleState.LOST) {
            dialogueText.text = "You were defeated";
        }
    }

    void PlayerTurn() {
        dialogueText.text = "Choose an action:";
    }

    int CalculateDamage(int atk, int def) {
        return (int)Math.Floor(atk * (1000 / (1000 + (def / 2.5))));
    }

    CharacterBattlePortrait getNextAliveHero() {
        int i = 0;
        foreach (CharacterBattlePortrait charBP in heroList) {
            if (heroList[i].thisCharBD.state != charState.DEAD && i < 4) {
                return heroList[i];
            }
            i++;
        }
        return heroList[3];
    }

    void updateAliveHeroes() {
        int i = 0;
        foreach (CharacterBattlePortrait charBP in heroList) {
            CharacterBattleData thisCharBD = charBP.thisCharBD;
            if (thisCharBD.state != charState.DEAD) {
                charBP.Enable();
                i++;
            }
        }
        numberOfHeroesAlive = i;
        if (numberOfHeroesAlive == 0) {
            state = BattleState.LOST;
            EndBattle();
        }
        else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void updateAliveEnemies() {
        int i = 0;
        foreach (CharacterBattlePortrait charBP in enemiesList) {
            CharacterBattleData thisCharBD = charBP.thisCharBD;
            if (thisCharBD.state != charState.DEAD) {
                i++;
            }
        }
        numberOfEnemiesAlive = i;
        if (numberOfEnemiesAlive == 0) {
            state = BattleState.WON;
            EndBattle();
        }
    }
}