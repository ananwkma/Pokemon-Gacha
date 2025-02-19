using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static int TEAM_SIZE_MAX = 4;
    public static CharacterCollection cc = new CharacterCollection();
    public static CharacterCollection PresetTeam = new CharacterCollection();

    public static int gems = 100000;
    public static CharacterIcon selectedCharacter;
        
    [System.Serializable]
    public class CharacterCollection {
        public List<Character> characterCollection = new List<Character>();
        public void Add(Character character) {
            characterCollection.Add(character);
        }
    }

    public static bool isMaxTeamSize() {
        return PresetTeam.characterCollection.Count >= TEAM_SIZE_MAX ? true : false;
    }
}
