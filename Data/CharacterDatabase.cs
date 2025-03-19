using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// atk,  def,  hp,  mp,  rarity

public class CharacterDatabase : MonoBehaviour
{
    static Character Common = new Character("Clefairy", "common", "", "Dialogues/common/commonDialogue", new Stats (100, 120, 50, 5, 1));
    static Character Common2 = new Character("Caterpie", "common2", "", "Dialogues/common2/common2Dialogue", new Stats (110, 115, 30, 5, 1));
    static Character Common3 = new Character("Pidgey", "common3", "", "Dialogues/common3/common3Dialogue", new Stats (130, 10, 40, 5, 1));
    static Character Rare = new Character("Pikachu", "rare", "", "Dialogues/rare/rareDialogue", new Stats (200, 250, 300, 5, 3));
    static Character Rare2 = new Character("Onix", "rare2", "", "Dialogues/rare2/rare2Dialogue", new Stats (240, 225, 140, 5, 3));
    static Character Rare3 = new Character("Jolteon", "rare3", "", "Dialogues/rare3/rare3Dialogue", new Stats (180, 270, 220, 5, 3));
    static Character Super = new Character("Charizard", "super", "", "Dialogues/super/superDialogue", new Stats (1000, 900, 2000, 5, 5));
    static Character Super2 = new Character("Venusaur", "super2", "", "Dialogues/super2/super2Dialogue", new Stats (1300, 700, 1800, 5, 5));
    static Character Super3 = new Character("Blastoise", "super3", "", "Dialogues/super3/super3Dialogue", new Stats (1450, 1200, 2200, 5, 5));
    
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
