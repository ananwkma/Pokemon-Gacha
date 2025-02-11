using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamBuilderController : MonoBehaviour
{
    public static List<Character> teamComp;
    private static int TEAMSIZEMAX = 4;

    public static void AddToTeamComp(Character character) {
        if (teamComp.Count < TEAMSIZEMAX) {
            teamComp.Add(character);
        }
    }

    public void RemoveFromTeamComp(Character character) {
        if (teamComp.Count > 0) {
            teamComp.Remove(character);
        }
    }
}
