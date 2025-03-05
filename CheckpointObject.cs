using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CheckpointObject : MonoBehaviour
{
    public TMP_Text levelText;
    public Checkpoint thisCheckpoint;
    public Button checkpointButton;

    void Start() {
        if (thisCheckpoint.Completed) {
            checkpointButton.interactable = false;
        }
        levelText.text = thisCheckpoint.World + "-" + thisCheckpoint.Level;
    }
}
