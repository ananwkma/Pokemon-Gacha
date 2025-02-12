using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static List<Character> teamComp;
    private static int TEAMSIZEMAX = 4;

    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    int selectedSlot = -1;

    public bool AddItem(Item item) {

        for (int i = 0; i < inventorySlots.Length; i++) {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null) {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot) {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>(); 
        inventoryItem.InitializeItem(item);
    }

    void ChangeSelectedSlot(int newValue) {
        if(selectedSlot >= 0) {
            inventorySlots[selectedSlot].Deselect();
        }
        
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public Item GetSelectedItem(bool use) {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null) {
            Item item = itemInSlot.item;
            Debug.Log(item);
            return item;
        }

        return null;
    }

    public static void AddToTeamComp(Character character) {
        if (teamComp.Count < TEAMSIZEMAX) {
            teamComp.Add(character);
        }
    }

    public void RemoveFromTeamComp(Character character) {
        if (teamComp.Count > 0) {
            teamComp.Remove(character);
        }
    }

    

    public void InventorySlotClicked() {

    }

    private void Update() {
        if (Input.inputString != null) {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8) {
                ChangeSelectedSlot(number - 1);
            }
        }
    }
}
