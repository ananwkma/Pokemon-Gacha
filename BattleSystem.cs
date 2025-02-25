using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public HeroSlot playerPrefab;
    public HeroSlot enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;
    
    private GameObject hero;
    private GameObject enemy;

    public TMP_Text dialogueText;

    public BattleState state;

    private int turnCount = 0;
    private int numberOfHeroesAlive = Player.cc.PresetTeam.Count;
    private int movesRemaining = Player.cc.PresetTeam.Count;
    public static List<Character> enemies = new List<Character>();
    private int numberOfEnemiesAlive = enemies.Count;
    [SerializeField] private Transform HeroContainer;
    [SerializeField] private HeroSlot heroSlotPrefab;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() {
        foreach (Character hero in Player.cc.PresetTeam) {
            HeroSlot playerGO = Instantiate(heroSlotPrefab, playerBattleStation);
            playerUnit = playerGO.GetComponent<Unit>();
            playerUnit.unitName = hero.Name;
            playerUnit.maxHP = hero.Stats.Hp;
            playerUnit.currentHP = hero.Stats.Hp;
            playerGO.SetHUD(playerUnit);
            playerGO.heroImage.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + hero.Title);
        }

        HeroSlot enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        enemyGO.SetHUD(enemyUnit);

        dialogueText.text = "A wild " + enemyUnit.unitName + " has appeared!";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    
    IEnumerator PlayerAttack() {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        // enemyUnit.SetHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful";

        yield return new WaitForSeconds(2f);
        
        if (isDead) {
            state = BattleState.WON;
            EndBattle();
        }
        else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    
    IEnumerator EnemyTurn() {
        dialogueText.text = enemyUnit.unitName + " attacks";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        // playerUnit.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if (isDead) {
            state = BattleState.LOST;
            EndBattle();
        }
        else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator PlayerHeal() {
        playerUnit.Heal(5);

        // playerUnit.SetHP(playerUnit.currentHP);
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