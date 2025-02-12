using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterCollectionItem : MonoBehaviour
{
    Image characterIcon;
    public Item myItem { get; set; }

    void Awake()
    {
        characterIcon = GetComponent<Image>();
    }

    public void Initialize(Item item)
    {
        myItem = item;
        characterIcon.sprite = item.image;
    }
}
