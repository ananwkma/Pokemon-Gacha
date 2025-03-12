using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public string description;
    public Sprite icon;
    public int manaCost;

    public abstract void Activate(CharacterBattleData user, CharacterBattleData target);
}

public class Buffs {
    public int AtkBuff;
    public int DefBuff;
    public int HPMaxBuff;
    public int MPMaxBuff;
    public int HPRecBuff;
    public int MPRecBuff; 
}

[CreateAssetMenu(fileName = "New Attack Ability", menuName = "Abilities/Attack")]
public class AttackAbility : Ability
{
    public int damage;

    public override void Activate(CharacterBattleData user, CharacterBattleData target)
    {
        int finalDamage = Mathf.Max(1, damage + user.GetAtk() - target.GetDef());
        target.TakeDamage(finalDamage);
        Debug.Log($"{user.thisChar.Name} used {abilityName} on {target.thisChar.Name}, dealing {finalDamage} damage!");
    }
}

[CreateAssetMenu(fileName = "New Heal Ability", menuName = "Abilities/Heal")]
public class HealAbility : Ability
{
    public int healAmount;

    public override void Activate(CharacterBattleData user, CharacterBattleData target)
    {
        target.Heal(healAmount);
        Debug.Log($"{user.thisChar.Name} healed {target.thisChar.Name} for {healAmount} HP!");
    }
}