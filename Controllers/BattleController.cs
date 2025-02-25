using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    private int turnCount = 0;
    private int numberOfHeroesAlive = Player.PresetTeam.Count;
    private int movesRemaining = Player.PresetTeam.Count;
    public static List<Character> enemies = new List<Character>();
    private int numberOfEnemiesAlive = enemies.Count;
    [SerializeField] private Transform HeroContainer;
    [SerializeField] private HeroSlot heroSlotPrefab;

    public bool IsGameOver() {
        return !(turnCount <= 20 && numberOfHeroesAlive > 0 && numberOfEnemiesAlive > 0);
    }

    public void CalculateDamage(Character hero, Character villain) {
        
    }

    void Start()
    {   
        foreach (CharacterIcon hero in Player.PresetTeam) {
            HeroSlot heroSlot = Instantiate(heroSlotPrefab, HeroContainer);
            heroSlot.heroImage.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + hero.Title);
        }
    }

    void Update()
    {
        
    }
}
