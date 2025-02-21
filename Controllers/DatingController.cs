using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class DatingController : MonoBehaviour
{
    public static DatingController Instance { get; private set; }

    [SerializeField] private GameObject DialogueParent;
    [SerializeField] private GameObject responseButtonPrefab;
    [SerializeField] private Transform responseButtonContainer;
    [SerializeField] private Image CharacterImage;
    [SerializeField] private TMP_Text ConversationText, CharacterNameText;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            Debug.Log("success");
        }
        else {
            Destroy(gameObject);
            Debug.Log("failed");
        }
        HideDialogue();
    }
    
    public void StartDialogue(string title, DialogueNode node) {
        ShowDialogue();
        CharacterNameText.text = title;
        ConversationText.text = node.dialogueText;

        foreach (Transform child in responseButtonContainer) {
            Destroy(child.gameObject);
        }

        foreach (DialogueResponse response in node.responses) {
            GameObject buttonObj = Instantiate(responseButtonPrefab, responseButtonContainer);
            Debug.Log("default text: " + buttonObj.GetComponentInChildren<TextMeshProUGUI>().text);
            Debug.Log("response.responseText: " + response.responseText);

            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = response.responseText;
            buttonObj.GetComponent<Button>().onClick.AddListener(() => SelectResponse(response, title));
        }
    }

    public void SelectResponse(DialogueResponse response, string title) {
        if (response.nextNode != null) {
            StartDialogue(title, response.nextNode);
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
