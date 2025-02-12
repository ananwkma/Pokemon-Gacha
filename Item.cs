using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    public Sprite iconSprite;
    public string characterName;
    public string title;
    public string description; 
    public int atk;
    public int def;
    public int hp;
    public int mp;
    public int rarity;
}

public enum ItemType {
    Common,
    Rare,
    Super
}