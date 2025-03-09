using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public enum charState { DEAD, READY, STANDBY, STUNNED, ASLEEP, POISONED, CONFUSED, WEAKENED }

public class CharacterBattleData : MonoBehaviour
{
    public Character thisChar;
    public CharacterBattlePortrait thisCharBP;
    
    public int CurrentHP;
    public int MaxHP;    
    public int CurrentMP;
    public int MaxMP;
    public int AtkMOD;
    public int DefMOD;
    
    public charState state;

    void Awake() {
        thisCharBP = GetComponentInParent<CharacterBattlePortrait>();
        state = charState.READY;
    }

    public void SetCharBD(Character character) {
        thisChar = character;
        SetFullHp();
        SetFullMp();
        ResetBuffs();
    }

    public int GetAtk() {
        return thisChar.Stats.Atk * AtkMOD;
    }

    public int GetDef() {
        return thisChar.Stats.Def * DefMOD;
    }

    public void TakeDamage(int dmg) {
        CurrentHP -= dmg;

        if (CurrentHP <= 0) {
            state = charState.DEAD;
            thisCharBP.Dead();
        }
    }

    public void Heal(int amount) {
        CurrentHP += amount;
        if (CurrentHP > MaxHP)  {
            CurrentHP = MaxHP; 
        }
    }

    public void SetFullHp() {        
        MaxHP = thisChar.Stats.Hp;
        CurrentHP = thisChar.Stats.Hp;
    }  

    public void SetFullMp() {        
        CurrentMP = thisChar.Stats.Mp;
        MaxMP = thisChar.Stats.Mp;
    }    

    public void ResetBuffs() {
        AtkMOD = 1;
        DefMOD = 1;
    }
    
    public void ApplyModifiers() {
        
    }

    public void ApplyBuffs() {
        
    }
}
