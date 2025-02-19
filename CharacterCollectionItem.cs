using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterIconCollection : MonoBehaviour
{
    Image characterIconImage;
    public CharacterIcon myCharacterIcon { get; set; }

    void Awake()
    {
        characterIconImage = GetComponent<Image>();
    }

    public void Initialize(CharacterIcon characterIcon)
    {
        myCharacterIcon = characterIcon;
        characterIconImage.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + characterIcon.Title);
    }
}
