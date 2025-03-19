using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoBarController : MonoBehaviour
{
    public static InfoBarController Instance { get; private set; }
    public TMP_Text gems;
    
    public void UpdateGems() {
        gems.text = Player.gems.ToString();
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (gems) gems.text = Player.gems.ToString();
    }
}
