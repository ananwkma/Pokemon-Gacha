using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    static Character Common = Character.CreateInstance("Gun Guy", "common", "", new Stats (100, 120, 50, 100, 1));
    static Character Common2 = Character.CreateInstance("Haunted Plushie", "common2", "", new Stats (110, 115, 30, 20, 1));
    static Character Common3 = Character.CreateInstance("Little Demon", "common3", "", new Stats (130, 10, 40, 55, 1));
    static Character Rare = Character.CreateInstance("Loli", "rare", "", new Stats (200, 250, 300, 120, 3));
    static Character Rare2 = Character.CreateInstance("Davi", "rare2", "", new Stats (240, 225, 140, 80, 3));
    static Character Rare3 = Character.CreateInstance("Annie", "rare3", "", new Stats (180, 270, 220, 220, 3));
    static Character Super = Character.CreateInstance("Sea Goddess", "super", "", new Stats (1000, 900, 2000, 1500, 5));
    static Character Super2 = Character.CreateInstance("Fortune Teller", "super2", "", new Stats (1300, 700, 1800, 2500, 5));
    static Character Super3 = Character.CreateInstance("Hot Demon", "super3", "", new Stats (1450, 1200, 2200, 1900, 5));
    
    // static Character Common = new Character("Gun Guy", "common", "", new Stats (100, 120, 50, 100, 1));
    // static Character Common2 = new Character("Haunted Plushie", "common2", "", new Stats (110, 115, 30, 20, 1));
    // static Character Common3 = new Character("Little Demon", "common3", "", new Stats (130, 10, 40, 55, 1));
    // static Character Rare = new Character("Loli", "rare", "", new Stats (200, 250, 300, 120, 3));
    // static Character Rare2 = new Character("Davi", "rare2", "", new Stats (240, 225, 140, 80, 3));
    // static Character Rare3 = new Character("Annie", "rare3", "", new Stats (180, 270, 220, 220, 3));
    // static Character Super = new Character("Sea Goddess", "super", "", new Stats (1000, 900, 2000, 1500, 5));
    // static Character Super2 = new Character("Fortune Teller", "super2", "", new Stats (1300, 700, 1800, 2500, 5));
    // static Character Super3 = new Character("Hot Demon", "super3", "", new Stats (1450, 1200, 2200, 1900, 5));
    
    public static Character[] rollTableCommon =
    {
        Common,
        Common2,
        Common3,
    };
    public static Character[] rollTableRare =
    {
        Rare,
        Rare2,
        Rare3,
    };
    public static Character[] rollTableSuper =
    {
        Super,
        Super2,
        Super3,
    };
}
