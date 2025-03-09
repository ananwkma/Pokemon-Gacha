using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class BattleMapController : MonoBehaviour
{   
    public Checkpoint currentCheckPoint; 
    public CheckpointObject checkpointGOPrefab;
    [SerializeField] private Transform checkpointGOContainer;

    void Awake() {
        int worldIndex = Player.worldIndex;
        int levelIndex = Player.levelIndex;

        currentCheckPoint = BattleMapDatabase.allWorlds[worldIndex][levelIndex];

        for (int i = 0; i < BattleMapDatabase.allWorlds[worldIndex].Length; i++) {
            Checkpoint checkpoint = BattleMapDatabase.allWorlds[worldIndex][i];

            if (i < levelIndex) {
                checkpoint.completeCheckpoint();
            }
             
            CheckpointObject checkpointGO = Instantiate(checkpointGOPrefab, checkpointGOContainer);
            checkpointGO.Initialize(checkpoint);
        }
    }
}
