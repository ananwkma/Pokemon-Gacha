using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class BattleMapController : MonoBehaviour
{   
    public Checkpoint currentCheckPoint; 
    public CheckpointObject checkpointGOPrefab;
    [SerializeField] private Transform checkpointGOContainer;

    void Start() {
        int worldIndex = Player.battleProgress[0]-1;
        int levelIndex = Player.battleProgress[1]-1;

        currentCheckPoint = BattleMapDatabase.allWorlds[worldIndex][levelIndex];

        for (int i = 0; i < BattleMapDatabase.allWorlds[worldIndex].Length; i++) {
            Checkpoint checkpoint = BattleMapDatabase.allWorlds[worldIndex][i];

            if (i < levelIndex) {
                checkpoint.completeCheckpoint();
            }
             
            CheckpointObject checkpointGO = Instantiate(checkpointGOPrefab, checkpointGOContainer);
            checkpointGO.thisCheckpoint = checkpoint;
        }
    }
}
