using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue Node", menuName = "Dialogue/Dialogue Node")]
public class DialogueNode : ScriptableObject {
    [TextArea] public string dialogueText;
    public List<DialogueResponse> responses;
}
