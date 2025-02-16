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
}
