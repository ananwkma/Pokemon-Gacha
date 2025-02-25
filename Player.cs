using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int TEAM_SIZE_MAX = 4;
    public static CharacterCollection cc = new CharacterCollection();
    // public static List<CharacterIcon> PresetTeam = new List<CharacterIcon>();

    public static int gems = 100000;
    // public static CharacterIcon selectedCharacter;
    public static Character selectedCharacter;
        
    [System.Serializable]
    public class CharacterCollection {
        public List<Character> PresetTeam = new List<Character>();
        public List<Character> characterCollection = new List<Character>();

        public void Add(Character character) {
            characterCollection.Add(character);
        }
        
        public void AddToTeam(Character character) {
            PresetTeam.Add(character);
        }

        public void Count() {
            // characterCollection.Count;
        }
    }

    public static bool isMaxTeamSize() {
        return cc.PresetTeam.Count >= TEAM_SIZE_MAX ? true : false;
    }
}
