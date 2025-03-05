using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    private string name;
    private string title;
    private string description;
    private Stats stats;
    [SerializeField] private string id;

    private int currentHP;
    private int maxHP;

    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Id { get; set; }
    public Stats Stats { get; set; }

    public int CurrentHP { get; set; }
    public int MaxHP { get; set; }

    public Character() { }
    
    public Character(string name, string title, string description, Stats stats, string id)
    {
        Name = name;
        Title = title;
        Description = description;
        Stats = stats;
        Id = id;
    }

    public Character(string name, string title, string description, Stats stats)
    {
        Name = name;
        Title = title;
        Description = description;
        Stats = stats;
    }

    //enemy
    public Character(string name, string title, Stats stats)
    {
        Name = name;
        Title = title;
        Stats = stats;
    }

    public Character(Character clone)
    {
        Name = clone.Name;
        Title = clone.Title;
        Description = clone.Description;
        Id = clone.Id;
        Stats = new Stats(clone.Stats);
    }

    public Character Clone()
    {
        return new Character(this);
    }

    public bool TakeDamage(int dmg) {
        CurrentHP -= dmg;

        if (CurrentHP <= 0) {
            return true;
        }
        else {
            return false;
        }
    }

    public void Heal(int amount) {
        CurrentHP += amount;
        if (CurrentHP > MaxHP)  {
            CurrentHP = MaxHP; 
        }
    }

    public void SetFullHp() {        
        maxHP = this.Stats.Hp;
        currentHP = this.Stats.Hp;
    }
}

public class Stats
{
    private int atk;
    private int def;
    private int hp;
    private int mp;
    private int rarity;

    public int Atk { get; set; }
    public int Def { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public int Rarity { get; set; }
    
    public Stats() { }
    
    public Stats(int atk, int def, int hp, int mp, int rarity)
    {
        Atk = atk;
        Def = def;
        Hp = hp;
        Mp = mp;
        Rarity = rarity;    
    }
    
    //enemy
    public Stats(int atk, int def, int hp, int mp)
    {
        Atk = atk;
        Def = def;
        Hp = hp;
        Mp = mp;   
    }
    
    public Stats(Stats clone)
    {
        Atk = clone.Atk;
        Def = clone.Def;
        Hp = clone.Hp;
        Mp = clone.Mp;
        Rarity = clone.Rarity;
    }
}
