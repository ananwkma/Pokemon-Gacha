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

    public string Name { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Stats Stats { get; set; }

    public Character() { }
    
    public Character(string name, string title, string description, Stats stats)
    {
        Name = name;
        Title = title;
        Description = description;
        Stats = stats;
    }
}

public class Stats
{
    private int atk;
    private int def;
    private int hp;
    private int mp;
    private int rarity;

    public int ATK { get; set; }
    public int DEF { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int Rarity { get; set; }
    
    public Stats() { }
    
    public Stats(int atk, int def, int hp, int mp, int rarity)
    {
        ATK = atk;
        DEF = def;
        HP = hp;
        MP = mp;
        Rarity = rarity;    
    }
}
