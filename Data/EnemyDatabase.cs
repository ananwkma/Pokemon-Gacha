using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// atk,  def,  hp,  mp,  rarity
public class EnemyDatabase : MonoBehaviour
{
    public static Character Enemy1 = new Character("Rhydon", "enemy1", new Stats (300, 120, 3000, 1200));
    public static Character Enemy2 = new Character("Lapras", "enemy2", new Stats (350, 115, 4000, 2000));
    public static Character Enemy3 = new Character("Dragonite", "enemy3", new Stats (500, 200, 5000, 5500));
}
