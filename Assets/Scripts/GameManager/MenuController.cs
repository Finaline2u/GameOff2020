using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void NewGame() {
        LevelLoader.instance.LoadNextLevel();
    }

    public void Quit() {
        Application.Quit();
    }

}
