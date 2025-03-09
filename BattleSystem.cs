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

        numberOfHeroesAlive = heroList.Count;
        numberOfEnemiesAlive = enemiesList.Count;
        movesRemaining = heroList.Count;

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
        CharacterBattleData selectedEnemyBD = selectedEnemyBP.thisCharBD;

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
        if (state != BattleState.ENEMYTURN) yield break;
        
        CharacterBattlePortrait selectedEnemyBP = enemiesList[0];
        CharacterBattleData selectedEnemyBD = selectedEnemyBP.thisCharBD;
        CharacterBattlePortrait selectedHeroBP = getNextAliveHero();

        Debug.Log("nextAlive: " + getNextAliveHero());
        if (selectedHeroBP != null)
        {
            CharacterBattleData selectedHeroBD = selectedHeroBP.thisCharBD;

            int damage = CalculateDamage(selectedEnemyBD.GetAtk(), selectedHeroBD.GetDef());
            dialogueText.text = $"{selectedEnemyBD.thisChar.Name} attacks!";

            yield return new WaitForSeconds(1f);

            selectedHeroBD.TakeDamage(damage);
            selectedHeroBP.SetHP(damage);

            updateAliveHeroes();
            movesRemaining = numberOfHeroesAlive;        
        }
        else
        {
            Debug.Log("No heroes are alive.");
        }
    }

    void EndBattle() {
        EndScreen.gameObject.SetActive(true);

        dialogueText.text = state == BattleState.WON ? "You won the battle!" : "You were defeated";
        if (state == BattleState.WON) {
            Player.IncrementCheckpoint();
        }
    }

    void PlayerTurn() {
        dialogueText.text = "Choose an action:";
    }

    int CalculateDamage(int atk, int def) {
        return (int)Math.Floor(atk * (1000 / (1000 + (def / 2.5))));
    }

    CharacterBattlePortrait getNextAliveHero() {
        return heroList.Find(charBP => charBP.thisCharBD.state != charState.DEAD);
    }

    void updateAliveHeroes() {
        int aliveCount = 0;
        
        foreach (CharacterBattlePortrait charBP in heroList) {
            CharacterBattleData thisCharBD = charBP.thisCharBD;
            
            if (thisCharBD.state != charState.DEAD) {
                charBP.Enable();
                aliveCount++;
            }
        }
        
        numberOfHeroesAlive = aliveCount;

        if (numberOfHeroesAlive == 0) {
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void updateAliveEnemies() {
        numberOfEnemiesAlive = enemiesList.FindAll(charBP => charBP.thisCharBD.state != charState.DEAD).Count;

        if (numberOfEnemiesAlive == 0)
        {
            state = BattleState.WON;
            EndBattle();
        }

    }
}