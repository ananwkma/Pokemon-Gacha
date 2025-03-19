using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character
{
    private string name;
    private string title;
    private string description;
    private string dialogueDatabasePath;
    private Stats stats;
    [SerializeField] private string id;

    public string Name;
    public string Title;
    public string Description;
    public string DialogueDatabasePath;
    public Stats Stats;
    public string Id;

    [System.NonSerialized]
    public DialogueDatabase CharacterDialogues;


    public Character() { }
    
    public Character(string name, string title, string description, string dialogueDatabasePath, Stats stats, string id)
    {
        Name = name;
        Title = title;
        Description = description;
        Stats = stats;
        Id = id;
        DialogueDatabasePath = dialogueDatabasePath;
        LoadDialogueDatabase();
    }

    public Character(string name, string title, string description, Stats stats)
    {
        Name = name;
        Title = title;
        Description = description;
        Stats = stats;
    }
    
    public Character(string name, string title, string description, string dialogueDatabasePath, Stats stats)
    {
        Name = name;
        Title = title;
        Description = description;
        Stats = stats;
        DialogueDatabasePath = dialogueDatabasePath;        
        LoadDialogueDatabase();
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
        DialogueDatabasePath = clone.DialogueDatabasePath;
        Id = clone.Id;
        Stats = new Stats(clone.Stats);
    }

    public Character Clone()
    {
        return new Character(this);
    }

    public void LoadDialogueDatabase()
    {
        if (!string.IsNullOrEmpty(DialogueDatabasePath))
        {
            CharacterDialogues = Resources.Load<DialogueDatabase>(DialogueDatabasePath);
            if (CharacterDialogues == null)
                Debug.LogError($"Failed to load DialogueDatabase from path: {DialogueDatabasePath}");
        }
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