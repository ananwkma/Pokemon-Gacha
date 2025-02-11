using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TeamSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData) {
        if (transform.childCount == 0) {
            GameObject dropped = eventData.pointerDrag;
            CharacterIcon characterIcon = eventData.pointerDrag.GetComponent<CharacterIcon>();
            characterIcon.parentAfterDrag = transform;
        }
    }
}
