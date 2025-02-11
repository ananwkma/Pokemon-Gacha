using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavManager : MonoBehaviour
{  
    public void LoadHome() {
        SceneManager.LoadScene (sceneBuildIndex: 0);
    }

    public void LoadGachaScene() {
        SceneManager.LoadScene (sceneBuildIndex: 1);
    }

    public void LoadCharacterCollectionScene() {
        SceneManager.LoadScene (sceneBuildIndex: 2);
    }

    public void LoadBattleMapScene() {
        SceneManager.LoadScene (sceneBuildIndex: 3);
    }

    public void LoadCharacterScene() {
        SceneManager.LoadScene (sceneBuildIndex: 4);
    }

    public void LoadDatingScene() {
        SceneManager.LoadScene (sceneBuildIndex: 5);
    }

    public void LoadTeamBuilderScene() {
        SceneManager.LoadScene (sceneBuildIndex: 6);
    }

    public void LoadBattleScene() {
        SceneManager.LoadScene (sceneBuildIndex: 7);
    }

    public static int GetActiveScene() {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
