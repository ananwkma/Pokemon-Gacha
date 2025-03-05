using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;


public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private static BattleSystem instance;

    public static BattleSystem GetInstance() {
        return instance;
    }

    public CharacterBattlePortrait heroPrefab;
    public CharacterBattlePortrait enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public TMP_Text dialogueText;

    public BattleState state;

    private int turnCount = 0;

    private int numberOfHeroesAlive;
    private int numberOfEnemiesAlive;
    private int movesRemaining;

    public static List<CharacterBattlePortrait> heroList = new List<CharacterBattlePortrait>();
    public static List<CharacterBattlePortrait> enemiesList = new List<CharacterBattlePortrait>();

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() {
        foreach (Character hero in Player.cc.PresetTeam) {
            // Debug.Log("presetteam " + JsonConvert.SerializeObject(hero, Formatting.Indented));
            CharacterBattlePortrait heroGO = Instantiate(heroPrefab, playerBattleStation);
            heroGO.thisChar = hero;
            heroGO.SetHUD();
            heroGO.heroImage.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + hero.Title);
            heroList.Add(heroGO);
        }

        Checkpoint currentCheckPoint = Player.GetCurrentCheckpoint();

        foreach (Character enemy in currentCheckPoint.Enemies) {            
            CharacterBattlePortrait enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
            enemyGO.thisChar = enemy;
            enemyGO.SetHUD();
            enemyGO.heroImage.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + enemy.Title);
            enemiesList.Add(enemyGO);
        }

        numberOfHeroesAlive = Player.cc.PresetTeam.Count;
        numberOfEnemiesAlive = enemiesList.Count;
        movesRemaining = Player.cc.PresetTeam.Count;

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    
    public IEnumerator PlayerAttack() {
        // bool isDead = enemyChar.TakeDamage(playerChar.Stats.Atk);

        // enemyChar.SetHP(enemyChar.currentHP);
        dialogueText.text = "The attack is successful";

        yield return new WaitForSeconds(2f);
        
        if (movesRemaining == 0) {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        // if (isDead) {
        //     state = BattleState.WON;
        //     EndBattle();
        // }
        // else {
        //     state = BattleState.ENEMYTURN;
        //     StartCoroutine(EnemyTurn());
        // }
    }
    
    IEnumerator EnemyTurn() {
        // dialogueText.text = enemyChar.Name + " attacks";

        yield return new WaitForSeconds(1f);

        // bool isDead = playerChar.TakeDamage(enemyChar.Stats.Atk);

        // playerChar.SetHP(playerChar.currentHP);

        yield return new WaitForSeconds(1f);

        // if (isDead) {
        //     state = BattleState.LOST;
        //     EndBattle();
        // }
        // else {
        //     state = BattleState.PLAYERTURN;
        //     PlayerTurn();
        // }
    }

    IEnumerator PlayerHeal() {
        // playerChar.Heal(5);

        // playerChar.SetHP(playerChar.currentHP);
        dialogueText.text = "You feel renewed strength!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    void EndBattle() {
        if (state == BattleState.WON) {
            dialogueText.text = "You won the battle!";
        }
        else if (state == BattleState.LOST) {
            dialogueText.text = "You were defeated";
        }
    }

    void PlayerTurn() {
        dialogueText.text = "Choose an action:";
    }

    public void OnAttackButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        StartCoroutine(PlayerHeal());
    }
}