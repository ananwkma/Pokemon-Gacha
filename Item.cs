using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string CharacterName;
    public string Title;
    public string Description; 
    public int Atk;
    public int Def;
    public int Hp;
    public int Mp;
    public int Rarity;

    public Item (string characterName, string title, string description, int atk, int def, int hp, int mp, int rarity)
    {
        CharacterName = characterName;
        Title = title;
        Description = description;
        Atk = atk;
        Def = def;
        Hp = hp;
        Mp = mp;
        Rarity = rarity;
    }
}

public enum ItemType {
    Common,
    Rare,
    Super
}

