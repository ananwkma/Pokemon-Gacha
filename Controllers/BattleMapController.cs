using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class BattleMapController : MonoBehaviour
{   
    public Checkpoint currentCheckPoint; 
    [SerializeField] private CheckpointObject checkpointGOPrefab;
    [SerializeField] private Transform checkpointGOContainer;

    void Awake() {
        if (!IsValidPlayerState()) return;

        int worldIndex = Player.worldIndex;
        int levelIndex = Player.levelIndex;

        currentCheckPoint = BattleMapDatabase.allWorlds[worldIndex][levelIndex];

        for (int i = 0; i < BattleMapDatabase.allWorlds[worldIndex].Length; i++) {
            Checkpoint checkpoint = BattleMapDatabase.allWorlds[worldIndex][i];

            if (i < levelIndex) {
                checkpoint.completeCheckpoint();
            }
            
            InstantiateCheckpoint(checkpoint);
        }
    }

    private bool IsValidPlayerState() {
        if (BattleMapDatabase.allWorlds == null ||
            Player.worldIndex >= BattleMapDatabase.allWorlds.Length ||
            Player.levelIndex >= BattleMapDatabase.allWorlds[Player.worldIndex].Length) {
                Debug.LogError("Invalid world or level index in BattleMapDatabase");
                return false;
            }
        return true;
    }

    private void InstantiateCheckpoint(Checkpoint checkpoint) {
        if (checkpointGOPrefab == null || checkpointGOContainer == null) {
            Debug.LogError("Checkpoint prefab or container is missing");
            return;
        }

        CheckpointObject checkpointGO = Instantiate(checkpointGOPrefab, checkpointGOContainer);
        checkpointGO.Initialize(checkpoint);
    }
}
