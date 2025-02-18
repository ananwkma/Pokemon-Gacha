using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterCollectionItem : MonoBehaviour
{
    Image characterIcon;
    public InventoryItem myItem { get; set; }

    void Awake()
    {
        characterIcon = GetComponent<Image>();
    }

    public void Initialize(InventoryItem item)
    {
        myItem = item;
        characterIcon.sprite = Resources.Load<Sprite>("Sprites/FullRender/" + item.Title);
    }
}
