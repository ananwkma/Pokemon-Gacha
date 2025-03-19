using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using Newtonsoft.Json;

public class InteractionController : MonoBehaviour
{
    public static InteractionController Instance { get; private set; }

    [SerializeField] private GameObject DialogueParent;
    [SerializeField] private GameObject responseButtonPrefab;
    [SerializeField] private Transform responseButtonContainer;
    [SerializeField] private Image CharacterImage;
    [SerializeField] private TMP_Text ConversationText, CharacterNameText;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }
        
        CharacterImage.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + Player.selectedCharacter.Title);
        CharacterNameText.text = Player.selectedCharacter.Name;
        
        StartDialogue(Resources.Load<DialogueDatabase>(Player.selectedCharacter.DialogueDatabasePath).dialogues[0]);
    }
    
    public void StartDialogue(DialogueNode node) {
        if (node == null) {
            Debug.LogError("Dialogue node is missing!");
            return;
        }

        ShowDialogue();
        ConversationText.text = node.dialogueText;

        foreach (Transform child in responseButtonContainer) {
            Destroy(child.gameObject);
        }

        foreach (DialogueResponse response in node.responses) {
            GameObject buttonObj = Instantiate(responseButtonPrefab, responseButtonContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = response.responseText;
            buttonObj.GetComponent<Button>().onClick.AddListener(() => SelectResponse(response));
        }
    }

    public void SelectResponse(DialogueResponse response) {
        if (response.nextNode != null) {
            StartDialogue(response.nextNode);
        }
        else {
            HideDialogue();
        }
    }

    public void HideDialogue()
    {
        DialogueParent.SetActive(false);
    }

    private void ShowDialogue()
    {
        DialogueParent.SetActive(true);
    }

    public bool IsDialogueActive()
    {
        return DialogueParent.activeSelf;
    }
}
