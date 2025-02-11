using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCollection : MonoBehaviour
{
    [SerializeField] private CharacterIcon characterIcon;

    string GetContainerTag(int sceneIndex) {
        switch (sceneIndex) {
            case 2:
                return "CharacterCollection";
            case 6: 
                return "CharacterSelection";
            default:
                return "";
        }
    } 

    void LoadCharacters() {
        // int i = 0;
        // int ICONIMAGEWIDTH = 100;
        // string containerTag = GetContainerTag(SceneNavManager.GetActiveScene());

        // foreach (Character hero in SaveData.cc.characterCollection) {
        //     CharacterIcon currentCharIcon = Instantiate(characterIcon) as CharacterIcon;
        //     currentCharIcon.transform.SetParent (GameObject.FindGameObjectWithTag(containerTag).transform, false);
        //     currentCharIcon.Icon.sprite = Resources.Load<Sprite>("Sprites/Icons/" + hero.Title);
        //     currentCharIcon.MyCharacter = hero; 
        //     i++;
        // }
    }

    void Start()
    {
        LoadCharacters();
    }
}
