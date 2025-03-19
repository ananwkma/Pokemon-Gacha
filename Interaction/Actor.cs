using UnityEngine;

public class Actor : MonoBehaviour
{
    public string Name;
    public Dialogue Dialogue;

    public void SpeakTo() {
        InteractionController.Instance.StartDialogue(Name, Dialogue.RootNode);
    }
    
    void Start() {
        SpeakTo();
    }
}

