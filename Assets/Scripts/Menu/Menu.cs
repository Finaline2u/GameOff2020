using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject settingsCanvas;

    public void NewGame() {
        LevelLoader.instance.LoadNextLevel();
    }

    public void Exit() {
        Application.Quit();
    }

    public void FullscreenToggle() {
        //if (EventSystem.current.gameObject.GetComponent<Toggle>().isOn) {}
            Screen.fullScreen = !Screen.fullScreen;
    }

    public void Settings() {
        if (!settingsCanvas.activeSelf) {
            menuCanvas.SetActive(false);
            settingsCanvas.SetActive(true);
        }
        else {
            menuCanvas.SetActive(true);
            settingsCanvas.SetActive(false);
        }
    }

}
