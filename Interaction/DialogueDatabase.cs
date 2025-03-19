using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Database", menuName = "Dialogue/Database")]
public class DialogueDatabase : ScriptableObject
{
    public List<DialogueNode> dialogues;
}
