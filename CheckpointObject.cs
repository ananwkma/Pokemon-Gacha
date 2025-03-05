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

    public void Initialize(Checkpoint checkpoint) {
        thisCheckpoint = checkpoint;
        levelText.text = thisCheckpoint.World + "-" + thisCheckpoint.Level;
        checkpointButton.interactable = !thisCheckpoint.Completed;
    }
    
    void Awake() {
        checkpointButton.interactable = false;
    }
}
