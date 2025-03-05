using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyDatabase;

public class BattleMapDatabase : MonoBehaviour
{
    static Checkpoint Checkpoint1_1 = new Checkpoint(1, 1, new Character[] { Enemy1 }, false);
    static Checkpoint Checkpoint1_2 = new Checkpoint(1, 2, new Character[] { Enemy2 }, false);
    static Checkpoint Checkpoint1_3 = new Checkpoint(1, 3, new Character[] { Enemy3 }, false);
    static Checkpoint Checkpoint1_4 = new Checkpoint(1, 4, new Character[] { Enemy1, Enemy1 }, false);
    static Checkpoint Checkpoint1_5 = new Checkpoint(1, 5, new Character[] { Enemy1, Enemy2, Enemy3 }, false);
    
    static Checkpoint Checkpoint2_1 = new Checkpoint(2, 1, new Character[] { Enemy3, Enemy3, Enemy3 }, false);
    
    public static Checkpoint[] world1Enemies =
    {
        Checkpoint1_1,
        Checkpoint1_2,
        Checkpoint1_3,
        Checkpoint1_4,
        Checkpoint1_5
    };

    public static Checkpoint[] world2Enemies =
    {
        Checkpoint2_1,
    };

    public static Checkpoint[][] allWorlds = {
        world1Enemies,
        world2Enemies
    };
}
