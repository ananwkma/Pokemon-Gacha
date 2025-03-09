using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int TEAM_SIZE_MAX = 4;
    public static CharacterCollection cc = new CharacterCollection();

    public static int gems = 100000;
    public static Character selectedCharacter;
    
    public static int worldIndex = 0;
    public static int levelIndex = 2;
        
    void Awake() {
        UpdateCheckpointIndices();
    }

    [System.Serializable]
    public class CharacterCollection {
        public List<Character> PresetTeam = new List<Character>();
        public List<Character> characterCollection = new List<Character>();

        public void Add(Character character) {
            characterCollection.Add(character);
        }
        
        public void AddToTeam(Character character) {
            int i = FindNextAvailableSlot();
            if (i == -1) {
                PresetTeam.Add(character);
            }
            else {
                PresetTeam[i] = character;
            }
        }
        
        public int FindNextAvailableSlot () {
            for (int i = 0; i < PresetTeam.Count; i++) {
                if (PresetTeam[i] == null) {
                    return i;
                }
            }
            return -1;
        }
    }

    public static bool isMaxTeamSize() {
        int count = 0;
        for (int i = 0; i < cc.PresetTeam.Count; i++) {
            if (cc.PresetTeam[i] != null) count++;
        }
        return count < TEAM_SIZE_MAX ? false : true;
    }
    
    public static Checkpoint GetCurrentCheckpoint() {
        return BattleMapDatabase.allWorlds[worldIndex][levelIndex];
    }

    public static void UpdateCheckpointIndices() {
        // worldIndex = battleProgress[0]-1;
        // levelIndex = battleProgress[1]-1;
    }

    public static void IncrementCheckpoint() {
        if (BattleMapDatabase.allWorlds[worldIndex][levelIndex + 1] != null) {
            levelIndex++;
        }
        else if (BattleMapDatabase.allWorlds[worldIndex + 1][0] != null) {
            levelIndex = 0;
            worldIndex++;
        }
    }
}
