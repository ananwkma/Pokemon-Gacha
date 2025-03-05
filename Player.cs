using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int TEAM_SIZE_MAX = 4;
    public static CharacterCollection cc = new CharacterCollection();

    public static int gems = 100000;
    public static Character selectedCharacter;
    
    public static int[] battleProgress = new int[] { 1, 3 };
    public static int worldIndex = battleProgress[0]-1;
    public static int levelIndex = battleProgress[1]-1;
        
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
}
